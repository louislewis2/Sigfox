namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.Devices.Queries;
    using Api.Devices.ViewModels;

    public static class DeviceHandler
    {
        #region Fields

        private const string resourceUrl = "devices";

        #endregion Fields

        #region Methods

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

        #endregion Methods
    }
}
