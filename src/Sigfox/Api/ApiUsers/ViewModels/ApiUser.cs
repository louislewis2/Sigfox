namespace Sigfox.Api.ApiUsers.ViewModels
{
    using Groups.ViewModels;
    using Shared.ViewModels;

    public class ApiUser
    {
        #region Constructor

        public ApiUser(string name, string timezone, MinimalGroup group, long creationTime, string id, string accessToken, Profile[] profiles)
        {
            this.Name = name;
            this.Timezone = timezone;
            this.Group = group;
            this.CreationTime = creationTime;
            this.Id = id;
            this.AccessToken = accessToken;
            this.Profiles = profiles;
        }

        #endregion Constructor

        #region Properties

        public string Name { get; }
        public string Timezone { get; }
        public MinimalGroup Group { get; }
        public long CreationTime { get; }
        public string Id { get; }
        public string AccessToken { get; }
        public Profile[] Profiles { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods
    }
}
