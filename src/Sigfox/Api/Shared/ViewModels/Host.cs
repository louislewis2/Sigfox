namespace Sigfox.Api.Shared.ViewModels
{
    public class Host
    {
        #region Constructor

        public Host(string device, string deviceUrl, string deviceType, string time, string data, string snr, string status, string message, CallbackMedium callback)
        {
            this.Device = device;
            this.DeviceUrl = deviceUrl;
            this.DeviceType = deviceType;
            this.Time = time;
            this.Data = data;
            this.Snr = snr;
            this.Status = status;
            this.Message = message;
            this.Callback = callback;
        }

        #endregion Constructor

        #region Properties

        public string Device { get; }
        public string DeviceUrl { get; }
        public string DeviceType { get; }
        public string Time { get; }
        public string Data { get; }
        public string Snr { get; }
        public string Status { get; }
        public string Message { get; }
        public CallbackMedium Callback { get; }

        #endregion Properties
    }
}
