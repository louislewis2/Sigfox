namespace Sigfox.Api.Shared.ViewModels
{
    using Groups.ViewModels;
    using Profiles.ViewModels;

    public class Role
    {
        #region Constructor

        public Role(MinimalGroup group, Profile profile)
        {
            this.Group = group;
            this.Profile = profile;
        }

        #endregion Constructor

        #region Properties

        public MinimalGroup Group { get; }
        public Profile Profile { get; }

        #endregion Properties
    }
}
