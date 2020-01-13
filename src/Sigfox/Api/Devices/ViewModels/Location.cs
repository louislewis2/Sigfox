namespace Sigfox.Api.Devices.ViewModels
{
    public class Location
    {
        #region Constructor

        public Location(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        #endregion Constructor

        #region Properties

        public double Lat { get; }
        public double Lng { get; }

        #endregion Properties
    }
}
