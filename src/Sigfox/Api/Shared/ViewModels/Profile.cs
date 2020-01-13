namespace Sigfox.Api.Shared.ViewModels
{
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

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods
    }
}
