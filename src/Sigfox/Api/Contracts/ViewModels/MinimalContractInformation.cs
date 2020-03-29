namespace Sigfox.Api.Contracts.ViewModels
{
    public class MinimalContractInformation
    {
        #region Constructor

        public MinimalContractInformation(string id, string name, string[] actions, string[] resources)
        {
            this.Id = id;
            this.Name = name;
            this.Actions = actions;
            this.Resources = resources;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Name { get; }
        public string[] Actions { get; }
        public string[] Resources { get; }

        #endregion Properties
    }
}
