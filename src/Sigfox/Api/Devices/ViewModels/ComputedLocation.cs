namespace Sigfox.Api.Devices.ViewModels
{
    using Enums;

    public class ComputedLocation
    {
        #region Constructor

        public ComputedLocation(double lat, double lng, int radius, ComputedLocationSourceTypes source, string[] placeIds)
        {
            this.Lat = lat;
            this.Lng = lng;
            this.Radius = radius;
            this.Source = source;
            this.PlaceIds = placeIds;
        }

        #endregion Constructor

        #region Properties

        public double Lat { get; }
        public double Lng { get; }
        public int Radius { get; }
        public ComputedLocationSourceTypes Source { get; }
        public string[] PlaceIds { get; }

        #endregion Properties
    }
}
