namespace Sigfox.Api.Shared.ViewModels
{
    public class MinimalRole
    {
        #region Constructor

        public MinimalRole(string id, string name, MinimalRoleMetaData path)
        {
            this.Id = id;
            this.Name = name;
            this.Path = path;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Name { get; }
        public MinimalRoleMetaData Path { get; }

        #endregion Properties
    }
}
