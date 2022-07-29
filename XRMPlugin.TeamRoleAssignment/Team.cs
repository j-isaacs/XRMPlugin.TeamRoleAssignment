using System;
using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamManager
{
    class Team
    {
        private Entity TeamEntity;

        public Guid Id
        {
            get { return TeamEntity.Id; }
        }

        public string Name
        {
            get { return TeamEntity.GetAttributeValue<string>("name"); }
        }

        public Team(Entity teamEntity)
        {
            TeamEntity = teamEntity;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
