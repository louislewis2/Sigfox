namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.ApiUsers.Queries;
    using Api.ApiUsers.Criteria;
    using Api.ApiUsers.ViewModels;

    public static class ApiUserHandler
    {
        #region Fields

        private const string resourceUrl = "api-users";

        #endregion Fields

        #region Methods

        public static async Task<ApiUser> GetApiUser(this SigfoxIntegrationClient sigfoxIntegrationClient, string apiUserId)
        {
            return await sigfoxIntegrationClient.GetAsync<ApiUser>(resourceUrl: $"{resourceUrl}/{apiUserId}", queryString: null);
        }

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

        public static async Task<CreatedResponse> Create(this SigfoxIntegrationClient sigfoxIntegrationClient, CreateApiUserCriteria createApiUserCriteria)
        {
            return await sigfoxIntegrationClient.PostAsync<CreatedResponse>(resourceUrl: resourceUrl, data: createApiUserCriteria);
        }

        public static async Task<bool> Update(this SigfoxIntegrationClient sigfoxIntegrationClient, string apiUserId, UpdateApiUserCriteria updateApiUserCriteria)
        {
            return await sigfoxIntegrationClient.PutAsync(resourceUrl: $"{resourceUrl}/{apiUserId}", data: updateApiUserCriteria);
        }

        public static async Task<bool> DeleteApiUser(this SigfoxIntegrationClient sigfoxIntegrationClient, string apiUserId)
        {
            return await sigfoxIntegrationClient.DeleteAsync(resourceUrl: $"{resourceUrl}/{apiUserId}");
        }

        public static async Task<bool> AssociateProfilesForApiUser(this SigfoxIntegrationClient sigfoxIntegrationClient, string apiUserId, AssociateProfilesForApiUserCriteria associateProfilesForApiUserCriteria)
        {
            return await sigfoxIntegrationClient.PutAsync(resourceUrl: $"{resourceUrl}/{apiUserId}/profiles", data: associateProfilesForApiUserCriteria);
        }

        public static async Task<bool> DeleteProfileForApiUser(this SigfoxIntegrationClient sigfoxIntegrationClient, string apiUserId, string profieId)
        {
            return await sigfoxIntegrationClient.DeleteAsync(resourceUrl: $"{resourceUrl}/{apiUserId}/profiles/{profieId}");
        }

        public static async Task<Credential> CreateCredentialsForApiUser(this SigfoxIntegrationClient sigfoxIntegrationClient, string apiUserId)
        {
            return await sigfoxIntegrationClient.PutAsync<Credential>(resourceUrl: $"{resourceUrl}/{apiUserId}/renew-credential");
        }

        #endregion Methods
    }
}
