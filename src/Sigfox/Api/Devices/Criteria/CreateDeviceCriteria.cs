namespace Sigfox.Api.Devices.Criteria
{
    using Newtonsoft.Json;

    public class CreateDeviceCriteria
    {
        #region Properties

        /// <summary>
        /// The device's identifier (hexadecimal format)
        /// </summary>
        public string Id { get; set; }

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

        /// <summary>
        /// The device type's identifier this device is affected
        /// </summary>
        public string DeviceTypeId { get; set; }

        /// <summary>
        /// The device's PAC (Porting Access Code)
        /// </summary>
        public string Pac { get; set; }

        #endregion Properties
    }
}
