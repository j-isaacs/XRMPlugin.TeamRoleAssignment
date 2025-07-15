using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class User : ListEntity
    {
        public override string Name => 
            $"{entity.GetAttributeValue<string>("domainname")} — {entity.GetAttributeValue<string>("lastname")}, {entity.GetAttributeValue<string>("firstname")}";

        public override bool Disabled => entity.GetAttributeValue<bool>("isdisabled");

        public override string[] ListItems => new string[]
        {
            entity.GetAttributeValue<string>("domainname"),
            entity.GetAttributeValue<string>("lastname"),
            entity.GetAttributeValue<string>("firstname"),
            entity.GetAttributeValue<EntityReference>("businessunitid")?.Name,
            Disabled ? "Disabled" : "Enabled"
        };

        public List<AssignmentChange> AssignmentChanges { get; set; }

        public User(Entity entity) : base(entity) { }
    }
}