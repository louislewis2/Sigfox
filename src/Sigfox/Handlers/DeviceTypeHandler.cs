namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.DeviceTypes.Queries;
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

        #endregion Methods
    }
}
