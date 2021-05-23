namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Xunit;

    using Sigfox.Api.DeviceTypes.Enums;
    using Sigfox.Api.DeviceTypes.Queries;
    using Sigfox.Api.DeviceTypes.Criteria;

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

        [Fact]
        public async Task Can_Get_Callbacks()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDeviceTypes();

            // Act
            var callbacksArrayResponse = await client.GetCallbacks(deviceTypeId: devicesPagedResponse.Data.First().Id);

            // Assert
            Assert.NotNull(@object: callbacksArrayResponse);
        }

        [Fact]
        public async Task Can_Create_Callback()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDeviceTypes();
            var createCallbackCriteria = new CreateCallbackCriteria(
                channel: CallbackChannels.URL,
                callbackType: CallbackTypes.DATA,
                callbackSubtype: CallbackSubTypes.UPLINK,
                payloadConfig: string.Empty,
                enabled: true,
                url: "https://test-callback.somesite.com/",
                httpMethod: CallbackHttpMethods.POST,
                linePattern: string.Empty,
                headers: new Dictionary<string, string> { { "Authorization", "Bearer 1234567" } },
                sendSni: false,
                bodyTemplate: "{\"data\":\"{data}\", \"time\": \"{time}\"}",
                contentType: "application/json");

            // Act
            var createCallbackResponse = await client.CreateCallback(deviceTypeId: devicesPagedResponse.Data.First().Id, createCallbackCriteria: createCallbackCriteria);

            // Assert
            Assert.NotNull(@object: createCallbackResponse);
            Assert.True(condition: !string.IsNullOrEmpty(createCallbackResponse.Id));
        }

        [Fact]
        public async Task Can_Update_Callback()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDeviceTypes();
            var createCallbackCriteria = new CreateCallbackCriteria(
                channel: CallbackChannels.URL,
                callbackType: CallbackTypes.DATA,
                callbackSubtype: CallbackSubTypes.UPLINK,
                payloadConfig: string.Empty,
                enabled: true,
                url: "https://test-callback.somesite.com/",
                httpMethod: CallbackHttpMethods.POST,
                linePattern: string.Empty,
                headers: new Dictionary<string, string> { { "Authorization", "Bearer 1234567" } },
                sendSni: false,
                bodyTemplate: "{\"data\":\"{data}\", \"time\": \"{time}\"}",
                contentType: "application/json");

            var deviceTypeId = devicesPagedResponse.Data.First().Id;
            var createCallbackResponse = await client.CreateCallback(deviceTypeId: deviceTypeId, createCallbackCriteria: createCallbackCriteria);
            var callbacksArrayResponse = await client.GetCallbacks(deviceTypeId: deviceTypeId);
            var callbackToUpdate = callbacksArrayResponse?.Data.First(x => x.Id == createCallbackResponse.Id);
            var updateCallbackCriteria = new UpdateCallbackCriteria(callback: callbackToUpdate);
            updateCallbackCriteria.Enabled = false;
            updateCallbackCriteria.HttpMethod = CallbackHttpMethods.PUT;

            // Act
            var updateCallbackResponse = await client.UpdateCallback(
                callbackId: createCallbackResponse.Id,
                deviceTypeId: deviceTypeId,
                updateCallbackCriteria: updateCallbackCriteria);

            // Assert
            Assert.True(condition: updateCallbackResponse);
        }

        [Fact]
        public async Task Can_Delete_Callback()
        {
            // Arrange
            var client = this.GetClient();
            var devicesPagedResponse = await client.GetDeviceTypes();
            var createCallbackCriteria = new CreateCallbackCriteria(
                channel: CallbackChannels.URL,
                callbackType: CallbackTypes.DATA,
                callbackSubtype: CallbackSubTypes.UPLINK,
                payloadConfig: string.Empty,
                enabled: true,
                url: "https://test-callback.somesite.com/",
                httpMethod: CallbackHttpMethods.POST,
                linePattern: string.Empty,
                headers: new Dictionary<string, string> { { "Authorization", "Bearer 1234567" } },
                sendSni: false,
                bodyTemplate: "{\"data\":\"{data}\", \"time\": \"{time}\"}",
                contentType: "application/json");

            var deviceTypeId = devicesPagedResponse.Data.First().Id;
            var createCallbackResponse = await client.CreateCallback(deviceTypeId: deviceTypeId, createCallbackCriteria: createCallbackCriteria);
            var callbacksArrayResponse = await client.GetCallbacks(deviceTypeId: deviceTypeId);
            var callbackToDelete = callbacksArrayResponse?.Data.First(x => x.Id == createCallbackResponse.Id);


            // Act
            var deleteCallbackResponse = await client.DeleteCallback(callbackId: callbackToDelete.Id, deviceTypeId: deviceTypeId);

            // Assert
            Assert.True(condition: deleteCallbackResponse);
        }

        #endregion Methods
    }
}
