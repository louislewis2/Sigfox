namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.Devices.Queries;
    using Api.Devices.Criteria;
    using Api.Devices.ViewModels;

    public static class DeviceHandler
    {
        #region Fields

        private const string resourceUrl = "devices";

        #endregion Fields

        #region Methods

        public static async Task<Device> GetDevice(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceId)
        {
            return await sigfoxIntegrationClient.GetAsync<Device>(resourceUrl: $"{resourceUrl}/{deviceId}", queryString: null);
        }

        public static async Task<MessagesMetric> GetDeviceMessageNumbers(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceId)
        {
            return await sigfoxIntegrationClient.GetAsync<MessagesMetric>(resourceUrl: $"{resourceUrl}/{deviceId}/messages/metric", queryString: null);
        }

        public static async Task<PagedResponse<DeviceMessage>> GetDeviceMessages(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceId, DeviceMessageQuery deviceMessageQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<DeviceMessage>>(resourceUrl: $"{resourceUrl}/{deviceId}/messages", queryString: deviceMessageQuery.ToString());
        }

        public static async Task<PagedResponse<Device>> GetDevices(this SigfoxIntegrationClient sigfoxIntegrationClient, DeviceQuery deviceQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Device>>(resourceUrl: resourceUrl, queryString: deviceQuery.ToString());
        }

        public static async Task<PagedResponse<Device>> GetDevices(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Device>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<Device>> GetDevices(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Device>>(resourceUrl: resourceUrl, queryString: null);
        }

        public static async Task<CreatedResponse> Create(this SigfoxIntegrationClient sigfoxIntegrationClient, CreateDeviceCriteria createDeviceCriteria)
        {
            return await sigfoxIntegrationClient.PostAsync<CreatedResponse>(resourceUrl: resourceUrl, data: createDeviceCriteria);
        }
        public static async Task<bool> Update(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceId, UpdateDeviceCriteria updateDeviceCriteria)
        {
            return await sigfoxIntegrationClient.PutAsync(resourceUrl: $"{resourceUrl}/{deviceId}", data: updateDeviceCriteria);
        }

        public static async Task<bool> DeleteDevice(this SigfoxIntegrationClient sigfoxIntegrationClient, string deviceId)
        {
            return await sigfoxIntegrationClient.DeleteAsync(resourceUrl: $"{resourceUrl}/{deviceId}");
        }

        #endregion Methods
    }
}
