namespace Sigfox.Api
{
    public class CreatedResponse
    {
        #region Constructor

        public CreatedResponse(string id)
        {
            this.Id = id;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }

        #endregion Properties
    }
}
