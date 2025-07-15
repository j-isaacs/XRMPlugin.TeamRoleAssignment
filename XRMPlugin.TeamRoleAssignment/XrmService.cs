using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class XrmService
    {
        private readonly IOrganizationService service;
        private QueryExpression userQuery = null;

        public bool HasUserQuery => userQuery != null;

        public XrmService(IOrganizationService service) => this.service = service;

        private List<Entity> RetrieveAll(QueryExpression query)
        {
            var list = new List<Entity>();

            query.PageInfo = new PagingInfo
            {
                ReturnTotalRecordCount = true,
                PageNumber = 1,
                Count = 5000
            };
            while (query.PageInfo != null)
            {
                var response = service.RetrieveMultiple(query);

                list.AddRange(response.Entities);
                if (response.MoreRecords)
                {
                    query.PageInfo.PagingCookie = response.PagingCookie;
                    query.PageInfo.PageNumber++;
                }
                else
                    query.PageInfo = null;
            }

            list.TrimExcess();
            return list;
        }

        public List<ListEntity> GetList<T>() where T : ListEntity
        {
            var list = new List<ListEntity>();
            var typeName = typeof(T).Name;
            switch (typeName)
            {
                case "Team":
                    var teamQuery = new QueryExpression("team");
                    teamQuery.ColumnSet.AddColumns("name", "businessunitid");
                    teamQuery.Criteria.AddCondition("isdefault", ConditionOperator.Equal, false);
                    teamQuery.Criteria.AddCondition("teamtype", ConditionOperator.Equal, 0);
                    teamQuery.AddOrder("name", OrderType.Ascending);
                    list.AddRange(RetrieveAll(teamQuery).Select(t => new Team(t)));
                    break;
                case "Role":
                    var roleQuery = new QueryExpression("role");
                    roleQuery.ColumnSet.AddColumns("name", "businessunitid");
                    roleQuery.AddOrder("name", OrderType.Ascending);
                    list.AddRange(RetrieveAll(roleQuery).Select(r => new Role(r)));
                    break;
                case "View":
                    var viewQuery = new QueryExpression("savedquery");
                    viewQuery.ColumnSet.AddColumns("name", "fetchxml");
                    viewQuery.Criteria.AddCondition("querytype", ConditionOperator.Equal, 0);
                    viewQuery.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                    viewQuery.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, "systemuser");
                    viewQuery.AddOrder("name", OrderType.Ascending);
                    list.AddRange(RetrieveAll(viewQuery).Select(v => new View(v)));
                    viewQuery.EntityName = "userquery";
                    list.AddRange(RetrieveAll(viewQuery).Select(v => new View(v)));
                    break;
            }

            return list;
        }

        public List<ListEntity> GetUsers(ListEntity listEntity, HashSet<string> userList, string fetchXml, bool includeDisabled)
        {
            var users = new List<ListEntity>();
            userQuery = null;

            if (listEntity != null || userList != null | fetchXml != null)
            {
                userQuery = new QueryExpression("systemuser")
                {
                    Distinct = true,
                    NoLock = true,
                    ColumnSet = new ColumnSet("systemuserid", "domainname", "firstname", "lastname", "isdisabled", "businessunitid")
                };

                if (userList != null) userQuery.Criteria.AddCondition("domainname", ConditionOperator.In, userList.ToArray());
                else if (listEntity is AssignableEntity assignment)
                {
                    var assignmentLink = userQuery.AddLink(assignment.Details.linkEntity, "systemuserid", "systemuserid");
                    assignmentLink.LinkCriteria.AddCondition(assignment.Details.entityId, ConditionOperator.Equal, assignment.Id);
                }
                else if (listEntity is View view) fetchXml = view.FetchXml;

                if (!string.IsNullOrWhiteSpace(fetchXml))
                {
                    var fetchXmlToQueryRequest = new FetchXmlToQueryExpressionRequest()
                    {
                        FetchXml = fetchXml
                    };
                    var fetchXmlToQueryResponse = service.Execute(fetchXmlToQueryRequest) as FetchXmlToQueryExpressionResponse;
                    if (fetchXmlToQueryResponse.Query.EntityName != "systemuser")
                    {
                        throw new Exception("Invalid FetchXML: Must be for the System User entity.");
                    }
                    userQuery.Criteria = fetchXmlToQueryResponse.Query.Criteria;
                    userQuery.LinkEntities.AddRange(fetchXmlToQueryResponse.Query.LinkEntities);
                    userQuery.Orders.AddRange(fetchXmlToQueryResponse.Query.Orders);
                }

                if (!includeDisabled) userQuery.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);

                if (userQuery.Orders.Count == 0) userQuery.AddOrder("domainname", OrderType.Ascending);

                users.AddRange(RetrieveAll(userQuery).Select(u => new User(u)));
            }

            return users;
        }

        public string GetUserFetchXml()
        {
            if (userQuery != null)
            {
                var queryToFetchXmlRequest = new QueryExpressionToFetchXmlRequest()
                {
                    Query = userQuery
                };
                var queryToFetchXmlResponse = service.Execute(queryToFetchXmlRequest) as QueryExpressionToFetchXmlResponse;
                return queryToFetchXmlResponse.FetchXml;
            }
            else return "<fetch distinct=\"true\" mapping=\"logical\"><entity name=\"systemuser\"><attribute name=\"systemuserid\"/><attribute name=\"domainname\"/><attribute name=\"firstname\"/><attribute name=\"lastname\"/><attribute name=\"isdisabled\"/><attribute name=\"businessunitid\"/><order attribute=\"domainname\" descending=\"false\"/></entity></fetch>";
        }

        public void CalculateAssignmentChanges(List<User> users, AssignableEntity[] assignmentAdds, AssignableEntity[] assignmentRemoves)
        {
            var assignableEntities = assignmentAdds.Concat(assignmentRemoves).ToDictionary(a => a.Id, a => a);
            (var linkEntity, var entityId) = assignableEntities.First().Value.Details;

            var query = new QueryExpression(linkEntity) { NoLock = true, ColumnSet = new ColumnSet(true) };
            query.Criteria.AddCondition(entityId, ConditionOperator.In, assignableEntities.Keys.Select(a => a.ToString()).ToArray());
            query.Criteria.AddCondition("systemuserid", ConditionOperator.In, users.Select(u => u.Id.ToString()).ToArray());

            var currentAssignments = RetrieveAll(query).ToLookup(e => (Guid)e["systemuserid"], e => assignableEntities[(Guid)e[entityId]]);
            foreach (var user in users)
            {
                var assignments = currentAssignments[user.Id];
                user.AssignmentChanges = assignmentAdds.Except(assignments).Select(a => new AssignmentChange(user, a, true))
                    .Concat(assignmentRemoves.Intersect(assignments).Select(a => new AssignmentChange(user, a, false))).ToList();
            }
        }

        public IEnumerable<User> ExecuteAssignmentChanges(List<User> users)
        {
            var multipleRequest = new ExecuteMultipleRequest()
            {
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                }
            };

            var changes = new List<AssignmentChange>();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                if (user.AssignmentChanges.Count == 0)
                    yield return user;
                else
                    changes.AddRange(user.AssignmentChanges);

                if (changes.Count >= 100 || (users.Count == i + 1 && changes.Count > 0))
                {
                    multipleRequest.Requests = new OrganizationRequestCollection();
                    multipleRequest.Requests.AddRange(changes.Select(c => c.Request));
                    var multipleResult = (ExecuteMultipleResponse)service.Execute(multipleRequest);

                    var failedChanges = multipleResult.Responses.Where(r => r.Fault != null).Select(r => changes[r.RequestIndex]).ToHashSet();

                    foreach (var userChanges in changes.ToLookup(c => c.User))
                    {
                        foreach (var change in userChanges.Intersect(failedChanges))
                            change.Failed = true;

                        yield return userChanges.Key;
                    }

                    changes.Clear();
                }
            }
        }
    }
}
