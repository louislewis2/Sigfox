namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.Contracts.Queries;

    public class ContractTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Get_Contracts_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act
            var contractsPagedResponse = await client.GetContracts();

            // Assert
            Assert.NotNull(@object: contractsPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Contracts_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var contractQuery = new ContractQuery { Limit = 1 };

            // Act
            var contractsPagedResponse = await client.GetContracts(contractQuery: contractQuery);

            // Assert
            Assert.NotNull(@object: contractsPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Contracts_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var contractQuery = new ContractQuery { Limit = 1 };

            // Act
            var contractsPagedResponse1 = await client.GetContracts(contractQuery: contractQuery);
            var contractsPagedResponse2 = await client.GetContracts(paging: contractsPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: contractsPagedResponse1);
            Assert.NotNull(@object: contractsPagedResponse2);
        }

        [Fact]
        public async Task Can_Get_Contracts_With_Limit_And_Id()
        {
            // Arrange
            var client = this.GetClient();
            var contractsPagedResponse = await client.GetContracts();
            var contractQuery = new ContractQuery { Limit = 2, Name = contractsPagedResponse.Data.First().Name };

            // Act
            var contractsPagedResponse2 = await client.GetContracts(contractQuery: contractQuery);

            // Assert
            Assert.NotNull(@object: contractsPagedResponse2);
            Assert.Single(collection: contractsPagedResponse2.Data);
            Assert.Equal(expected: contractsPagedResponse.Data.First().Name, actual: contractsPagedResponse2.Data.First().Name);
        }

        [Fact]
        public async Task Can_Get_Contract()
        {
            // Arrange
            var client = this.GetClient();
            var contractsPagedResponse = await client.GetContracts();

            // Act
            var loadedContract = await client.GetContract(contractId: contractsPagedResponse.Data.First().Id);

            // Assert
            Assert.NotNull(@object: loadedContract);
        }

        [Fact]
        public async Task Can_Get_Contract_Devices()
        {
            // Arrange
            var client = this.GetClient();
            var contractsPagedResponse = await client.GetContracts();

            // Act
            var loadedContract = await client.GetContractDevices(contractId: contractsPagedResponse.Data.First().Id, contractDevicesQuery: new ContractDevicesQuery());

            // Assert
            Assert.NotNull(@object: loadedContract);
        }

        #endregion Methods
    }
}
