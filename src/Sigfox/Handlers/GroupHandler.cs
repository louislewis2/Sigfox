namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.Groups.Queries;
    using Api.Groups.Criteria;
    using Api.Groups.ViewModels;
    using Api.Shared.ViewModels;
    using Api.DeviceTypes.ViewModels;

    public static class GroupHandler
    {
        #region Fields

        private const string resourceUrl = "groups";

        #endregion Fields

        #region Methods

        public static async Task<Group> GetGroup(this SigfoxIntegrationClient sigfoxIntegrationClient, string groupId)
        {
            return await sigfoxIntegrationClient.GetAsync<Group>(resourceUrl: $"{resourceUrl}/{groupId}", queryString: null);
        }

        public static async Task<PagedResponse<Group>> GetGroups(this SigfoxIntegrationClient sigfoxIntegrationClient, GroupQuery groupQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Group>>(resourceUrl: resourceUrl, queryString: groupQuery.ToString());
        }

        public static async Task<PagedResponse<Group>> GetGroups(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Group>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<Group>> GetGroups(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Group>>(resourceUrl: resourceUrl, queryString: null);
        }

        public static async Task<CreatedResponse> Create(this SigfoxIntegrationClient sigfoxIntegrationClient, CreateGroupCriteria createGroupCriteria)
        {
            return await sigfoxIntegrationClient.PostAsync<CreatedResponse>(resourceUrl: resourceUrl, data: createGroupCriteria);
        }

        public static async Task<bool> Update(this SigfoxIntegrationClient sigfoxIntegrationClient, string groupId, UpdateGroupCriteria updateGroupCriteria)
        {
            return await sigfoxIntegrationClient.PutAsync(resourceUrl: $"{resourceUrl}/{groupId}", data: updateGroupCriteria);
        }

        public static async Task<bool> DeleteGroup(this SigfoxIntegrationClient sigfoxIntegrationClient, string groupId)
        {
            return await sigfoxIntegrationClient.DeleteAsync(resourceUrl: $"{resourceUrl}/{groupId}");
        }

        public static async Task<PagedResponse<Host>> GetGroupUndeliveredCallbacks(this SigfoxIntegrationClient sigfoxIntegrationClient, string groupId, UndeliveredCallbackQuery undeliveredCallbackQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Host>>(resourceUrl: $"{resourceUrl}/{groupId}/callbacks-not-delivered", queryString: undeliveredCallbackQuery.ToString());
        }

        public static async Task<PagedResponse<Host>> GetGroupUndeliveredCallbacks(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Host>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<GeoLocationPayloadConfig>> GetGroupGeoLocationPayloads(this SigfoxIntegrationClient sigfoxIntegrationClient, string groupId, GeolocationPayloadQuery geolocationPayloadQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<GeoLocationPayloadConfig>>(resourceUrl: $"{resourceUrl}/{groupId}/geoloc-payloads", queryString: geolocationPayloadQuery.ToString());
        }

        public static async Task<PagedResponse<GeoLocationPayloadConfig>> GetGroupGeoLocationPayloads(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<GeoLocationPayloadConfig>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        #endregion Methods
    }
}
