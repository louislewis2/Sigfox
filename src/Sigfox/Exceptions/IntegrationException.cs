namespace Sigfox.Exceptions
{
    using System;
    using System.Net.Http;

    using Api.Errors;

    public class IntegrationException : Exception
    {
        #region Constructor

        public IntegrationException(HttpResponseMessage httpResponseMessage, string reasonPhrase, ErrorResponse errorResponse = null) : base(message: reasonPhrase)
        {
            this.ErrorResponse = errorResponse;
            this.HttpResponseMessage = httpResponseMessage;
        }

        #endregion Constructor

        #region Properties

        public ErrorResponse ErrorResponse { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        #endregion Properties
    }
}
