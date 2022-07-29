using System;
using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamManager
{
    class View
    {
        private Entity ViewEntity;

        public Guid Id
        {
            get { return ViewEntity.Id; }
        }

        public string Name
        {
            get { return ViewEntity.GetAttributeValue<string>("name"); }
        }

        public string FetchXml
        {
            get { return ViewEntity.GetAttributeValue<string>("fetchxml"); }
        }

        public View(Entity viewEntity)
        {
            ViewEntity = viewEntity;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
