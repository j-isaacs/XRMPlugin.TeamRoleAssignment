using System;
using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamManager
{
    class Role
    {
        private Entity RoleEntity;

        public Guid Id
        {
            get { return RoleEntity.Id; }
        }

        public string Name
        {
            get { return RoleEntity.GetAttributeValue<string>("name"); }
        }

        public Role(Entity roleEntity)
        {
            RoleEntity = roleEntity;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
