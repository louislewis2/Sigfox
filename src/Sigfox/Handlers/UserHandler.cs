namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.Users.Queries;
    using Api.Users.ViewModels;

    public static class UserHandler
    {
        #region Fields

        private const string resourceUrl = "users";

        #endregion Fields

        #region Methods

        public static async Task<PagedResponse<User>> GetUsers(this SigfoxIntegrationClient sigfoxIntegrationClient, UserQuery userQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<User>>(resourceUrl: resourceUrl, queryString: userQuery.ToString());
        }

        public static async Task<PagedResponse<User>> GetUsers(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<User>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<User>> GetUsers(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<User>>(resourceUrl: resourceUrl, queryString: null);
        }

        #endregion Methods
    }
}
