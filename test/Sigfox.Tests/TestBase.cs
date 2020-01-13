namespace Sigfox.Tests
{
    using System;

    using Sigfox;

    public class TestBase
    {
        #region Properties

        public string Login = ""; // Remove Value Before Comitting Code
        public string Password = ""; // Remove Value Before Comitting Code

        #endregion Properties

        #region Methods

        public SigfoxIntegrationClient GetClient()
        {
            if (string.IsNullOrWhiteSpace(value: this.Login) || string.IsNullOrWhiteSpace(value: this.Password))
            {
                throw new Exception(message: "Credentials Missing In TestBase.cs");
            }

            return new SigfoxIntegrationClient(login: this.Login, password: this.Password);
        }

        #endregion Methods
    }
}
