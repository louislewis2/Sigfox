namespace Sigfox.Api.DeviceTypes.Criteria
{
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using Enums;
    using ViewModels;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/updateCallback
    /// </summary>
    public class UpdateCallbackCriteria
    {
        #region Constructor

        public UpdateCallbackCriteria()
        {
        }

        public UpdateCallbackCriteria(Callback callback)
        {
            this.Channel = callback.Channel;
            this.CallbackType = callback.CallbackType;
            this.CallbackSubtype = callback.CallbackSubtype;
            this.PayloadConfig = callback.PayloadConfig;
            this.Enabled = callback.Enabled;
            this.Url = callback.Url;
            this.HttpMethod = callback.HttpMethod;
            this.Headers = callback.Headers;
            this.SendSni = callback.SendSni;
            this.BodyTemplate = callback.BodyTemplate;
            this.ContentType = callback.ContentType;
        }

        public UpdateCallbackCriteria(
            CallbackChannels channel,
            CallbackTypes callbackType,
            CallbackSubTypes callbackSubtype,
            string payloadConfig,
            bool enabled,
            string url,
            CallbackHttpMethods httpMethod,
            Dictionary<string, string> headers,
            bool sendSni,
            string bodyTemplate, 
            string contentType)
        {
            this.Channel = channel;
            this.CallbackType = callbackType;
            this.CallbackSubtype = callbackSubtype;
            this.PayloadConfig = payloadConfig;
            this.Enabled = enabled;
            this.Url = url;
            this.HttpMethod = httpMethod;
            this.Headers = headers;
            this.SendSni = sendSni;
            this.BodyTemplate = bodyTemplate;
            this.ContentType = contentType;
        }

        #endregion Constructor

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
        /// The headers of the http request to send, as an object with key:value. This field can be unset when updating.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Send SNI (Server Name Indication) for SSL/TLS connections. Used by BATCH_URL and URL callbacks (optional).
        /// </summary>
        public bool SendSni { get; set; }

        /// <summary>
        /// The body template of the request. Only if httpMethpd is set to POST or PUT. It can contain predefined and custom variables. Mandatory for URL callbacks. This field can be unset when updating.
        /// </summary>
        public string BodyTemplate { get; set; }

        /// <summary>
        /// The body media type of the request, only if httpMethpd is set to POST or PUT. This field can be unset when updating.
        /// </summary>
        public string ContentType { get; set; }

        #endregion Properties
    }
}
