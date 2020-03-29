namespace Sigfox.Api.Shared.ViewModels
{
    public class MinimalRoleMetaData
    {
        #region Constructor

        public MinimalRoleMetaData(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Name { get; }

        #endregion Properties
    }
}
