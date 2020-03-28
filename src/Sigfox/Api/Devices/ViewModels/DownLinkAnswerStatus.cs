namespace Sigfox.Api.Devices.ViewModels
{
    public class DownLinkAnswerStatus
    {
        #region Properties

        /// <summary>
        /// base station to send downlink message
        /// </summary>
        public MinimalBaseStation BaseStation { get; set; }

        /// <summary>
        /// planned downlink power as it was computed by the backend
        /// </summary>
        public double PlannedPower { get; set; }

        /// <summary>
        /// response content, hex encoded
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// name of the first operator which received the message as roaming
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// country of the operator
        /// </summary>
        public string Country { get; set; }

        #endregion Properties
    }
}
