namespace Sigfox.Api.Devices.ViewModels
{
    public class Certificate
    {
        #region Constructor

        public Certificate(string id, string key)
        {
            this.Id = id;
            this.Key = key;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Key { get; }

        #endregion Properties
    }
}
