namespace Sigfox.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.Groups.Enums;
    using Sigfox.Api.Groups.Queries;
    using Sigfox.Api.Groups.Criteria;

    public class GroupTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Get_Groups_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act
            var groupsPagedResponse = await client.GetGroups();

            // Assert
            Assert.NotNull(@object: groupsPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Groups_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var groupQuery = new GroupQuery { Limit = 1 };

            // Act
            var groupsPagedResponse = await client.GetGroups(groupQuery: groupQuery);

            // Assert
            Assert.NotNull(@object: groupsPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Groups_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var groupQuery = new GroupQuery { Limit = 1 };

            // Act
            var groupsPagedResponse1 = await client.GetGroups(groupQuery: groupQuery);
            var groupsPagedResponse2 = await client.GetGroups(paging: groupsPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: groupsPagedResponse1);
            Assert.NotNull(@object: groupsPagedResponse2);
        }

        [Fact]
        public async Task Can_Get_Groups_With_Limit_And_Id()
        {
            // Arrange
            var client = this.GetClient();
            var groupsPagedResponse = await client.GetGroups();
            var groupQuery = new GroupQuery { Limit = 2, Name = groupsPagedResponse.Data.First().Name };

            // Act
            var groupsPagedResponse2 = await client.GetGroups(groupQuery: groupQuery);

            // Assert
            Assert.NotNull(@object: groupsPagedResponse2);
            Assert.Single(collection: groupsPagedResponse2.Data);
            Assert.Equal(expected: groupsPagedResponse.Data.First().Name, actual: groupsPagedResponse2.Data.First().Name);
        }

        [Fact]
        public async Task Can_Create_Group()
        {
            // Arrange
            var client = this.GetClient();
            var createGroupCriteria = new CreateGroupCriteria(
                name: this.Random.Generate(10),
                description: "Test Group Description",
                type: GroupTypes.Other,
                timezone: "Europe/Paris",
                parentId: "5e1d9ed9e0102e186cb33db8",
                networkOperatorId: "");

            // Act
            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);

            // Assert
            Assert.NotNull(@object: createdResponse);
        }

        [Fact]
        public async Task Can_Get_Group()
        {
            // Arrange
            var client = this.GetClient();
            var createGroupCriteria = new CreateGroupCriteria(
                name: this.Random.Generate(10),
                description: "Test Group Description",
                type: GroupTypes.Other,
                timezone: "Europe/Paris",
                parentId: "5e1d9ed9e0102e186cb33db8",
                networkOperatorId: "");

            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);

            // Act
            var loadedGroup = await client.GetGroup(groupId: createdResponse.Id);

            // Assert
            Assert.NotNull(@object: loadedGroup);
        }

        [Fact]
        public async Task Can_Update_Group()
        {
            // Arrange
            var client = this.GetClient();
            var createGroupCriteria = new CreateGroupCriteria(
                name: this.Random.Generate(10),
                description: "Test Group Description",
                type: GroupTypes.Other,
                timezone: "Europe/Paris",
                parentId: "5e1d9ed9e0102e186cb33db8",
                networkOperatorId: "");

            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);
            var loadedGroup = await client.GetGroup(groupId: createdResponse.Id);
            var updateGroupCriteria = new UpdateGroupCriteria(group: loadedGroup);
            updateGroupCriteria.Name = this.Random.Generate(10);

            // Act
            var updateResponse = await client.Update(groupId: loadedGroup.Id, updateGroupCriteria: updateGroupCriteria);

            // Assert
            Assert.True(condition: updateResponse);
        }

        [Fact]
        public async Task Can_Delete_Group()
        {
            // Arrange
            var client = this.GetClient();
            var createGroupCriteria = new CreateGroupCriteria(
                name: this.Random.Generate(10),
                description: "Test Group Description",
                type: GroupTypes.Other,
                timezone: "Europe/Paris",
                parentId: "5e1d9ed9e0102e186cb33db8",
                networkOperatorId: "");

            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);

            // Act
            var deleteResponse = await client.DeleteGroup(groupId: createdResponse.Id);

            // Assert
            Assert.True(condition: deleteResponse);
        }

        [Fact]
        public async Task Can_Get_Group_UnDelivered_CallBacks()
        {
            // Arrange
            var client = this.GetClient();
            var createGroupCriteria = new CreateGroupCriteria(
                name: this.Random.Generate(10),
                description: "Test Group Description",
                type: GroupTypes.Other,
                timezone: "Europe/Paris",
                parentId: "5e1d9ed9e0102e186cb33db8",
                networkOperatorId: "");

            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);
            var undeliveredCallBackQuery = new UndeliveredCallbackQuery();

            // Act
            var undeliveredCallbacks = await client.GetGroupUndeliveredCallbacks(groupId: createdResponse.Id, undeliveredCallbackQuery: undeliveredCallBackQuery);

            // Assert
            Assert.NotNull(@object: undeliveredCallbacks);
        }

        [Fact]
        public async Task Can_Get_Group_GeoLocation_Payload()
        {
            // Arrange
            var client = this.GetClient();
            var createGroupCriteria = new CreateGroupCriteria(
                name: this.Random.Generate(10),
                description: "Test Group Description",
                type: GroupTypes.Other,
                timezone: "Europe/Paris",
                parentId: "5e1d9ed9e0102e186cb33db8",
                networkOperatorId: "");

            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);
            var geolocationPayloadQuery = new GeolocationPayloadQuery();

            // Act
            var undeliveredCallbacks = await client.GetGroupGeoLocationPayloads(groupId: createdResponse.Id, geolocationPayloadQuery: geolocationPayloadQuery);

            // Assert
            Assert.NotNull(@object: undeliveredCallbacks);
        }

        #endregion Methods
    }
}
