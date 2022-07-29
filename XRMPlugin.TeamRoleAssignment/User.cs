using System;
using Microsoft.Xrm.Sdk;

namespace XRMPlugin.TeamManager
{
    class User
    {
        private Entity UserEntity;

        public Guid Id
        {
            get { return UserEntity.Id; }
        }

        public string UserName
        {
            get { return UserEntity.GetAttributeValue<string>("domainname"); }
        }

        public string FirstName
        {
            get { return UserEntity.GetAttributeValue<string>("firstname"); }
        }

        public string LastName
        {
            get { return UserEntity.GetAttributeValue<string>("lastname"); }
        }

        public bool Disabled
        {
            get { return UserEntity.GetAttributeValue<bool>("isdisabled"); }
        }

        public string Status { get; set; }

        public User(Entity userEntity)
        {
            UserEntity = userEntity;
            Status = Disabled ? "Disabled" : "Enabled";
        }
    }
}
