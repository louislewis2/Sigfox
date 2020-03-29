namespace Sigfox.Api.Contracts.ViewModels
{
    using System.Collections.Generic;

    public class Option
    {
        #region Constructor

        public Option(string id, Dictionary<string, object> parameters)
        {
            this.Id = id;
            this.Parameters = parameters;
        }

        #endregion Constructor

        #region Properties

        public string Id { get;  }
        public Dictionary<string,object> Parameters { get; }

        #endregion Properties
    }
}
