namespace Sigfox.Api.DeviceTypes.Criteria
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using Enums;

    public class CreateCallbackCriteria
    {
        #region Properties

        /// <summary>
        /// The callback's channel.
        /// </summary>
        /// <example>createUrlCallback, createBatchUrlCallback, createEmailCallback</example>
        [JsonConverter(typeof(StringEnumConverter))]
        public CallbackChannels Channel { get; set; }

        /// <summary>
        /// The callback's type.
        /// </summary>
        public CallbackTypes CallbackType { get; set; }

        /// <summary>
        /// The callback's subtype. The subtype must be valid against its type.
        /// </summary>
        public CallbackSubTypes CallbackSubtype { get; set; }

        /// <summary>
        /// The custom payload configuration. Only for DATA and DATA_ADVANCED callbacks. This field can be unset when updating.
        /// </summary>
        public string PayloadConfig { get; set; }

        /// <summary>
        /// True to enable the callback, otherwise false
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The callback's url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The http method used to send a callback
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CallbackHttpMethods HttpMethod { get; set; }

        /// <summary>
        /// The line pattern representing a message.
        /// </summary>
        public string LinePattern { get; set; }

        #endregion Properties
    }
}
