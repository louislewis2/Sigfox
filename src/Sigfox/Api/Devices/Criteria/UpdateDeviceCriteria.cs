namespace Sigfox.Api.Devices.Criteria
{
    using Newtonsoft.Json;

    public class UpdateDeviceCriteria
    {
        #region Properties

        /// <summary>
        /// The device's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// true if the device is activable and can take a token. Not used if the device has already a token
        /// </summary>
        public bool Activable { get; set; }

        /// <summary>
        /// Allow token renewal ?
        /// </summary>
        public bool AutomaticRenewal { get; set; }

        /// <summary>
        /// The device's provided latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// The device's provided longitude
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        public UpdateCertificateCriteria ProductCertificate { get; set; }

        /// <summary>
        /// If the device is a prototype or not
        /// </summary>
        public bool Prototype { get; set; }

        #endregion Properties
    }
}
