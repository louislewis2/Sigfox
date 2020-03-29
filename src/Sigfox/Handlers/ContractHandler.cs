namespace Sigfox
{
    using System.Threading.Tasks;

    using Api;
    using Api.Contracts.Queries;
    using Api.Contracts.ViewModels;

    public static class ContractHandler
    {
        #region Fields

        private const string resourceUrl = "contract-infos";

        #endregion Fields

        #region Methods

        public static async Task<Contract> GetContract(this SigfoxIntegrationClient sigfoxIntegrationClient, string contractId)
        {
            return await sigfoxIntegrationClient.GetAsync<Contract>(resourceUrl: $"{resourceUrl}/{contractId}", queryString: null);
        }

        public static async Task<PagedResponse<Contract>> GetContracts(this SigfoxIntegrationClient sigfoxIntegrationClient, ContractQuery contractQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Contract>>(resourceUrl: resourceUrl, queryString: contractQuery.ToString());
        }

        public static async Task<PagedResponse<Contract>> GetContracts(this SigfoxIntegrationClient sigfoxIntegrationClient, Paging paging)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Contract>>(resourceUrl: resourceUrl, queryString: paging.ToString());
        }

        public static async Task<PagedResponse<Contract>> GetContracts(this SigfoxIntegrationClient sigfoxIntegrationClient)
        {
            return await sigfoxIntegrationClient.GetAsync<PagedResponse<Contract>>(resourceUrl: resourceUrl, queryString: null);
        }

        public static async Task<Contract> GetContractDevices(this SigfoxIntegrationClient sigfoxIntegrationClient, string contractId, ContractDevicesQuery contractDevicesQuery)
        {
            return await sigfoxIntegrationClient.GetAsync<Contract>(resourceUrl: $"{resourceUrl}/{contractId}/devices", queryString: contractDevicesQuery.ToString());
        }

        #endregion Methods
    }
}
