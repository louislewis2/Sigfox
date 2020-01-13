namespace Sigfox.Exceptions
{
    using System;
    using System.Net.Http;

    public class IntegrationException : Exception
    {
        #region Constructor

        public IntegrationException(HttpResponseMessage httpResponseMessage, string reasonPhrase) : base(message: reasonPhrase)
        {
            this.HttpResponseMessage = httpResponseMessage;
        }

        #endregion Constructor

        #region Properties

        public HttpResponseMessage HttpResponseMessage { get; }

        #endregion Properties
    }
}
