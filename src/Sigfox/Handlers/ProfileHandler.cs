namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.Profiles.Queries;
    using Api.Profiles.ViewModels;

    public static class ProfileHandler
    {
        #region Fields

        private const string resourceUrl = "profiles";

        #endregion Fields

        #region Methods

        public static async Task<PagedResponse<Profile>> GetProfiles(this SigfoxIntegrationClient sigfoxIntegrationClient, ProfileQuery profileQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Profile>>(resourceUrl: resourceUrl, queryString: profileQuery.ToString());
        }

        public static async Task<PagedResponse<Profile>> GetProfiles(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Profile>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<Profile>> GetProfiles(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Profile>>(resourceUrl: resourceUrl, queryString: null);
        }

        #endregion Methods
    }
}
