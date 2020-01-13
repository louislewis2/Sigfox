namespace Sigfox.Api.Users.ViewModels
{
    using Shared.ViewModels;

    public class User
    {
        #region Constructor

        public User(string firstName, string lastName, string timezone, string id, string email, bool locked, long creationTime, long lastLoginTime, Role[] userRoles)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Timezone = timezone;
            this.Id = id;
            this.Email = email;
            this.Locked = locked;
            this.CreationTime = creationTime;
            this.LastLoginTime = lastLoginTime;
            this.UserRoles = userRoles;
        }

        #endregion Constructor

        #region Properties

        public string FirstName { get; }
        public string LastName { get; }
        public string Timezone { get; }
        public string Id { get; }
        public string Email { get; }
        public bool Locked { get; }
        public long CreationTime { get; }
        public long LastLoginTime { get; }
        public Role[] UserRoles { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return this.FirstName;
        }

        #endregion Methods
    }
}
