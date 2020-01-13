namespace Sigfox.Api.DeviceTypes.ViewModels
{
    public class MinimalDeviceType
    {
        #region Constructor

        public MinimalDeviceType(string id, string name)
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
