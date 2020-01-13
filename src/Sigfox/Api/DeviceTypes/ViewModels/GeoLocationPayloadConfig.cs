namespace Sigfox.Api.DeviceTypes.ViewModels
{
    public class GeoLocationPayloadConfig
    {
        #region Constructor

        public GeoLocationPayloadConfig(string id, string name)
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
