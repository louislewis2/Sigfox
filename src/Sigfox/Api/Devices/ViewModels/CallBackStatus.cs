namespace Sigfox.Api.Devices.ViewModels
{
    using Newtonsoft.Json;

    public class CallBackStatus
    {
        #region Properties

        /// <summary>
        /// http response status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// http response message
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// callback definition triggered
        /// </summary>
        [JsonProperty("cbDef")]
        public string CallBackDefinition { get; set; }

        /// <summary>
        /// time the callback was called (in milliseconds since the Unix Epoch)
        /// </summary>
        public long Time { get; set; }

        #endregion Properties
    }
}
