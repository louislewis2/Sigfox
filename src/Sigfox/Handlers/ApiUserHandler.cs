namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.ApiUsers.Queries;
    using Api.ApiUsers.ViewModels;

    public static class ApiUserHandler
    {
        #region Fields

        private const string resourceUrl = "api-users";

        #endregion Fields

        #region Methods

        public static async Task<PagedResponse<ApiUser>> GetApiUsers(this SigfoxIntegrationClient sigfoxIntegrationClient, ApiUserQuery apiUserQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<ApiUser>>(resourceUrl: resourceUrl, queryString: apiUserQuery.ToString());
        }

        public static async Task<PagedResponse<ApiUser>> GetApiUsers(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<ApiUser>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<ApiUser>> GetApiUsers(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<ApiUser>>(resourceUrl: resourceUrl, queryString: null);
        }

        #endregion Methods
    }
}
