namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.DeviceTypes.Queries;

    public class DeviceTypeTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Get_Device_Types_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act
            var deviceTypesPagedResponse = await client.GetDeviceTypes();

            // Assert
            Assert.NotNull(@object: deviceTypesPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Device_Types_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var deviceTypeQuery = new DeviceTypeQuery { Limit = 1 };

            // Act
            var deviceTypesPagedResponse = await client.GetDeviceTypes(deviceTypeQuery: deviceTypeQuery);

            // Assert
            Assert.NotNull(@object: deviceTypesPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Device_Types_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var deviceTypeQuery = new DeviceTypeQuery { Limit = 1 };

            // Act
            var deviceTypesPagedResponse1 = await client.GetDeviceTypes(deviceTypeQuery: deviceTypeQuery);
            var deviceTypesPagedResponse2 = await client.GetDeviceTypes(paging: deviceTypesPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: deviceTypesPagedResponse1);
            Assert.NotNull(@object: deviceTypesPagedResponse2);
        }

        [Fact]
        public async Task Can_Get_Device_Types_With_Limit_And_Id()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDeviceTypes();
            var deviceTypeQuery = new DeviceTypeQuery { Limit = 2, Name = devicesPagedResponse.Data.First().Name };

            // Act
            var deviceTypesPagedResponse2 = await client.GetDeviceTypes(deviceTypeQuery: deviceTypeQuery);

            // Assert
            Assert.NotNull(@object: deviceTypesPagedResponse2);
            Assert.Single(collection: deviceTypesPagedResponse2.Data);
            Assert.Equal(expected: devicesPagedResponse.Data.First().Name, actual: deviceTypesPagedResponse2.Data.First().Name);
        }

        #endregion Methods
    }
}
