using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamRoleAssignment
{
    internal class AssignmentChange
    {
        public User User { get; set; }
        public AssignableEntity Assignment { get; set; }
        public bool IsAdd { get; set; }
        public bool Failed { get; set; }
        public OrganizationRequest Request => IsAdd ? Assignment.CreateAssignRequest(User.Id) : Assignment.CreateUnassignRequest(User.Id);

        public AssignmentChange(User user, AssignableEntity assignment, bool isAdd)
        {
            User = user;
            Assignment = assignment;
            IsAdd = isAdd;
        }

        public override string ToString() => $"{(IsAdd ? "Add to" : "Remove from")} {Assignment.GetType().Name} - {Assignment}";
    }
}
