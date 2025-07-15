using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamRoleAssignment
{
    class View : ListEntity
    {
        public string FetchXml => entity.GetAttributeValue<string>("fetchxml");

        public override string Group => entity.LogicalName == "savedquery" ? "System Views" : "User Views";

        public View(Entity entity) : base(entity) { }
    }
}