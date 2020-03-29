namespace Sigfox.Api.Profiles.ViewModels
{
    using Groups.ViewModels;
    using Shared.ViewModels;

    public class Profile
    {
        #region Constructor

        public Profile(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Name { get; }
        public MinimalGroup Group { get; }
        public MinimalRole[] Roles { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods
    }
}
