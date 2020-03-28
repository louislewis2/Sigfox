namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.Devices.Queries;

    public class DeviceTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Get_Devices_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act
            var devicesPagedResponse = await client.GetDevices();

            // Assert
            Assert.NotNull(@object: devicesPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Devices_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var deviceQuery = new DeviceQuery { Limit = 2 };

            // Act
            var devicesPagedResponse = await client.GetDevices(deviceQuery: deviceQuery);

            // Assert
            Assert.NotNull(@object: devicesPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Devices_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var deviceQuery = new DeviceQuery { Limit = 2 };

            // Act
            var devicesPagedResponse1 = await client.GetDevices(deviceQuery: deviceQuery);
            var devicesPagedResponse2 = await client.GetDevices(paging: devicesPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: devicesPagedResponse1);
            Assert.NotNull(@object: devicesPagedResponse2);
        }

        [Fact]
        public async Task Can_Get_Devices_With_Limit_And_Id()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDevices();
            var deviceQuery = new DeviceQuery { Limit = 2, Id = devicesPagedResponse.Data.First().Id };

            // Act
            var devicesPagedResponse2 = await client.GetDevices(deviceQuery: deviceQuery);

            // Assert
            Assert.NotNull(@object: devicesPagedResponse2);
            Assert.Single(collection: devicesPagedResponse2.Data);
            Assert.Equal(expected: devicesPagedResponse.Data.First().Id, actual: devicesPagedResponse2.Data.First().Id);
        }

        [Fact]
        public async Task Can_Get_Device()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDevices();

            // Act
            var device = await client.GetDevice(deviceId: devicesPagedResponse.Data.First().Id);

            // Assert
            Assert.NotNull(@object: device);
        }

        [Fact]
        public async Task Can_Get_Device_Message_Metric()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDevices();

            // Act
            var messageMetric = await client.GetDeviceMessageNumbers(deviceId: devicesPagedResponse.Data.First().Id);

            // Assert
            Assert.NotNull(@object: messageMetric);
        }

        [Fact]
        public async Task Can_Get_Device_Message_Messages()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDevices();

            // Act
            var deviceMessages = await client.GetDeviceMessages(deviceId: devicesPagedResponse.Data.First().Id, deviceMessageQuery: new DeviceMessageQuery());

            // Assert
            Assert.NotNull(@object: deviceMessages);
        }

        #endregion Methods
    }
}
