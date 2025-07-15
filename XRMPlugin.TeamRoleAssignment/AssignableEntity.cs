using System;
using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamRoleAssignment
{
    internal abstract class AssignableEntity : ListEntity
    {
        public abstract (string linkEntity, string entityId) Details { get; }

        protected AssignableEntity(Entity entity) : base(entity) { }

        public abstract OrganizationRequest CreateAssignRequest(Guid userId);
        public abstract OrganizationRequest CreateUnassignRequest(Guid userId);
    }
}