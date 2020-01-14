namespace Sigfox.Api.Shared.ViewModels
{
    public class CallbackMedium
    {
        #region Constructor

        public CallbackMedium(string subject, string message, string url, string headers, string body, string contentType, string method, string error)
        {
            this.Subject = subject;
            this.Message = message;
            this.Url = url;
            this.Headers = headers;
            this.Body = body;
            this.ContentType = contentType;
            this.Method = method;
            this.Error = error;
        }

        #endregion Constructor

        #region Properties

        public string Subject { get; }
        public string Message { get; }
        public string Url { get; }
        public string Headers { get; }
        public string Body { get; }
        public string ContentType { get; }
        public string Method { get; }
        public string Error { get; }

        #endregion Properties
    }
}
