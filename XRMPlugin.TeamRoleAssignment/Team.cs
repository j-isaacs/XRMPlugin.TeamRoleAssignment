using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class Team : AssignableEntity
    {
        public Team(Entity entity) : base(entity) { }

        public override (string linkEntity, string entityId) Details => ("teammembership", "teamid");

        public override OrganizationRequest CreateAssignRequest(Guid userId) => new AddMembersTeamRequest
        {
            TeamId = Id,
            MemberIds = new[] { userId }
        };

        public override OrganizationRequest CreateUnassignRequest(Guid userId) => new RemoveMembersTeamRequest
        {
            TeamId = Id,
            MemberIds = new[] { userId }
        };
    }
}