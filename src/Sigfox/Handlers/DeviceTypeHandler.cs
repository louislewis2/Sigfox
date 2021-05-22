namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.DeviceTypes.Queries;
    using Api.DeviceTypes.Criteria;
    using Api.DeviceTypes.ViewModels;

    public static class DeviceTypeHandler
    {
        #region Fields

        private const string resourceUrl = "device-types";

        #endregion Fields

        #region Methods

        public static async Task<PagedResponse<DeviceType>> GetDeviceTypes(this SigfoxIntegrationClient sigfoxIntegrationClient, DeviceTypeQuery deviceTypeQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<DeviceType>>(resourceUrl: resourceUrl, queryString: deviceTypeQuery.ToString());
        }

        public static async Task<PagedResponse<DeviceType>> GetDeviceTypes(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<DeviceType>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<DeviceType>> GetDeviceTypes(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<DeviceType>>(resourceUrl: resourceUrl, queryString: null);
        }

        public static async Task<ArrayResponse<Callback>> GetCallbacks(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceTypeId)
        {
            return await sigfoxIntegrationClient.GetAsync<ArrayResponse<Callback>>(resourceUrl: $"{resourceUrl}/{deviceTypeId}/callbacks", queryString: null);
        }

        public static async Task<CreatedResponse> CreateCallback(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceTypeId, CreateCallbackCriteria createCallbackCriteria)
        {
            return await sigfoxIntegrationClient.PostAsync<CreatedResponse>(resourceUrl: $"{resourceUrl}/{deviceTypeId}/callbacks", data: createCallbackCriteria);
        }

        public static async Task<bool> UpdateCallback(this SigfoxIntegrationClient sigfoxIntegrationClient, string callbackId, string deviceTypeId, UpdateCallbackCriteria updateCallbackCriteria)
        {
            return await sigfoxIntegrationClient.PutAsync(resourceUrl: $"{resourceUrl}/{deviceTypeId}/callbacks/{callbackId}", data: updateCallbackCriteria);
        }

        public static async Task<bool> DeleteCallback(this SigfoxIntegrationClient sigfoxIntegrationClient, string callbackId, string deviceTypeId)
        {
            return await sigfoxIntegrationClient.DeleteAsync(resourceUrl: $"{resourceUrl}/{deviceTypeId}/callbacks/{callbackId}");
        }

        #endregion Methods
    }
}
