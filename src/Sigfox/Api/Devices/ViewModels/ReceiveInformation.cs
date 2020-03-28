namespace Sigfox.Api.Devices.ViewModels
{
    using Newtonsoft.Json;

    public class ReceiveInformation
    {
        #region Properties

        /// <summary>
        /// Name and Id of the base station which has received the message.
        /// </summary>
        public MinimalBaseStation BaseStation { get; set; }

        /// <summary>
        /// The latitude of the base station that has received the message.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of the base station that has received the message.
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        /// <summary>
        /// the delay (in second) between sending and receiving the message, may not be present.
        /// </summary>
        public double Delay { get; set; }

        /// <summary>
        /// number of repetitions sent by the base station
        /// </summary>
        [JsonProperty("rep")]
        public double NumberOfRepetitions { get; set; }

        /// <summary>
        /// list of callback status for this reception
        /// </summary>
        [JsonProperty("cbStatus")]
        public CallBackStatus[] CallbackStatuses { get; set; }

        #endregion Properties
    }
}
