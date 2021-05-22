namespace Sigfox.Api.DeviceTypes.ViewModels
{
    using System.Collections.Generic;

    using Enums;

    public class Callback
    {
        #region Constructor

        public Callback(
            string id,
            CallbackChannels channel,
            CallbackTypes callbackType,
            CallbackSubTypes callbackSubtype,
            string payloadConfig,
            bool enabled,
            bool dead,
            string url,
            CallbackHttpMethods httpMethod,
            bool downlinkHook,
            Dictionary<string, string> headers,
            string bodyTemplate,
            string contentType, 
            bool sendSni)
        {
            this.Id = id;
            this.Channel = channel;
            this.CallbackType = callbackType;
            this.CallbackSubtype = callbackSubtype;
            this.PayloadConfig = payloadConfig;
            this.Enabled = enabled;
            this.Dead = dead;
            this.Url = url;
            this.HttpMethod = httpMethod;
            this.DownlinkHook = downlinkHook;
            this.Headers = headers;
            this.BodyTemplate = bodyTemplate;
            this.ContentType = contentType;
            this.SendSni = sendSni;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public CallbackChannels Channel { get; }
        public CallbackTypes CallbackType { get; }
        public CallbackSubTypes CallbackSubtype { get; }
        public string PayloadConfig { get; }
        public bool Enabled { get; }
        public bool Dead { get; }
        public string Url { get; }
        public CallbackHttpMethods HttpMethod { get; }
        public bool DownlinkHook { get; }
        public Dictionary<string, string> Headers { get; }
        public string BodyTemplate { get; }
        public string ContentType { get; }
        public bool SendSni { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"{this.HttpMethod} {this.Url}";
        }

        #endregion Methods
    }
}
