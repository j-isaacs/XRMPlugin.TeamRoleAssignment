using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class Role : AssignableEntity
    {
        public Role(Entity entity) : base(entity) { }

        public override (string linkEntity, string entityId) Details => ("systemuserroles", "roleid");

        public override OrganizationRequest CreateAssignRequest(Guid userId) => new AssociateRequest
        {
            Target = entity.ToEntityReference(),
            Relationship = new Relationship("systemuserroles_association"),
            RelatedEntities = new EntityReferenceCollection { new EntityReference("systemuser", userId) }
        };

        public override OrganizationRequest CreateUnassignRequest(Guid userId) => new DisassociateRequest
        {
            Target = entity.ToEntityReference(),
            Relationship = new Relationship("systemuserroles_association"),
            RelatedEntities = new EntityReferenceCollection { new EntityReference("systemuser", userId) }
        };
    }
}