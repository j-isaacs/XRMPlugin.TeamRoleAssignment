using Microsoft.Xrm.Sdk;
using System;

namespace XRMPlugin.TeamRoleAssignment
{
    internal abstract class ListEntity
    {
        protected readonly Entity entity;

        public Guid Id => entity.Id;

        public virtual string Name => entity.GetAttributeValue<string>("name");

        public virtual bool Disabled => false;

        public virtual string[] ListItems => new string[]
        {
            Name, entity.GetAttributeValue<EntityReference>("businessunitid")?.Name
        };

        public virtual string Group => null;

        protected ListEntity(Entity entity) => this.entity = entity;

        public override string ToString() => Name;
    }
}
