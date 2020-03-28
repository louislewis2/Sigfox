namespace Sigfox.Api.Devices.ViewModels
{
    using Newtonsoft.Json;

    using Enums;

    public class DeviceMessage
    {
        #region Properties

        /// <summary>
        /// Defines a device message
        /// </summary>
        public CommonDevice Device { get; set; }

        /// <summary>
        /// Timestamp of the message (in milliseconds since the Unix Epoch)
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// message content, hex encoded
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// true if an acknowledge is required
        /// </summary>
        [JsonProperty("ackRequired")]
        public bool AcknowledgeRequired { get; set; }

        /// <summary>
        /// link quality indicator 0 -> LIMIT 1 -> AVERAGE 2 -> GOOD 3 -> EXCELLENT 4 -> NA
        /// </summary>
        [JsonProperty("lqi")]
        public LinkQualityIndicatorTypes LinkQualityIndicator { get; set; }

        /// <summary>
        /// link quality indicator for repeated message 0 -> LIMIT 1 -> AVERAGE 2 -> GOOD 3 -> EXCELLENT 4 -> NA
        /// </summary>
        [JsonProperty("lqiRepeaters")]
        public LinkQualityIndicatorTypes LinkQualityRepeaters { get; set; }

        /// <summary>
        /// the sequence number for this message, may not be present when device uses VO protocol
        /// </summary>
        [JsonProperty("seqNumber")]
        public int SequenceNumber { get; set; }

        /// <summary>
        /// nbFrames can be 1 or 3. This value represents an expected number of frames sent by the device.
        /// </summary>
        [JsonProperty("nbFrames")]
        public int NumberOfFrames { get; set; }

        public ComputedLocation ComputedLocation { get; set; }

        [JsonProperty("rinfos")]
        public ReceiveInformation[] ReceiveInformationEntries { get; set; }

        public DownLinkAnswerStatus DownLinkAnswerStatus { get; set; }

        #endregion Properties
    }
}
