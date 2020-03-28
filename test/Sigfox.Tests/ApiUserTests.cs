namespace Sigfox.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.ApiUsers.Queries;
    using Sigfox.Api.ApiUsers.Criteria;
    using Sigfox.Exceptions;

    public class ApiUserTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Get_Api_Users_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act
            var apiUsersPagedResponse = await client.GetApiUsers();

            // Assert
            Assert.NotNull(@object: apiUsersPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Api_Users_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var apiUserQuery = new ApiUserQuery { Limit = 1 };

            // Act
            var apiUsersPagedResponse = await client.GetApiUsers(apiUserQuery: apiUserQuery);

            // Assert
            Assert.NotNull(@object: apiUsersPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Api_Users_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var apiUserQuery = new ApiUserQuery { Limit = 1 };

            // Act
            var apiUsersPagedResponse1 = await client.GetApiUsers(apiUserQuery: apiUserQuery);
            var apiUsersPagedResponse2 = await client.GetApiUsers(paging: apiUsersPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: apiUsersPagedResponse1);
            Assert.NotNull(@object: apiUsersPagedResponse2);
        }

        [Fact]
        public async Task Can_Get_Api_Users_With_Limit_And_Id()
        {
            // Arrange
            var client = this.GetClient();
            var apiUsersPagedResponse = await client.GetApiUsers();
            var apiUserQuery = new ApiUserQuery { Limit = 1, ProfileId = apiUsersPagedResponse.Data.First().Profiles.First().Id };

            // Act
            var apiUsersPagedResponse2 = await client.GetApiUsers(apiUserQuery: apiUserQuery);

            // Assert
            Assert.NotNull(@object: apiUsersPagedResponse2);
            Assert.Single(collection: apiUsersPagedResponse2.Data);
            Assert.Equal(expected: apiUsersPagedResponse.Data.First().Profiles.First().Id, actual: apiUsersPagedResponse2.Data.First().Profiles.First().Id);
        }

        [Fact]
        public async Task Can_Create_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d" });

            // Act
            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);

            // Assert
            Assert.NotNull(@object: createdResponse);
        }

        [Fact]
        public async Task Can_Get_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d" });

            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);

            // Act
            var loadedApiUser = await client.GetApiUser(apiUserId: createdResponse.Id);

            // Assert
            Assert.NotNull(@object: loadedApiUser);
        }

        [Fact]
        public async Task Can_Update_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d" });

            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);
            var loadedApiUser = await client.GetApiUser(apiUserId: createdResponse.Id);
            var updateApiUserCriteria = new UpdateApiUserCriteria(apiUser: loadedApiUser);
            updateApiUserCriteria.Name = this.Random.Generate(10);

            // Act
            var updateResponse = await client.Update(apiUserId: loadedApiUser.Id, updateApiUserCriteria: updateApiUserCriteria);

            // Assert
            Assert.True(condition: updateResponse);
        }

        [Fact]
        public async Task Can_Delete_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d" });

            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);

            // Act
            var deleteResponse = await client.DeleteApiUser(apiUserId: createdResponse.Id);

            // Assert
            Assert.True(condition: deleteResponse);
        }

        [Fact]
        public async Task Can_Create_Associate_Profiles_For_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d" });
            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);
            var associateProfilesForApiUser = new AssociateProfilesForApiUserCriteria(profileIds: new[] { "5617b5bfe4b036e1c1452746" });

            // Act
            var associatedResponse = await client.AssociateProfilesForApiUser(apiUserId: createdResponse.Id, associateProfilesForApiUser);

            // Assert
            Assert.True(condition: associatedResponse);
        }

        [Fact]
        public async Task Can_Create_Delete_Profile_For_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d", "5617b5bfe4b036e1c1452746" });
            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);

            // Act
            var deletedResponse = await client.DeleteProfileForApiUser(apiUserId: createdResponse.Id, profieId: "5617b5bfe4b036e1c1452746");

            // Assert
            Assert.True(condition: deletedResponse);
        }

        [Fact]
        public async Task Can_Create_Credentials_For_Api_User()
        {
            // Arrange
            var client = this.GetClient();
            var createApiUserCriteria = new CreateApiUserCriteria(
                groupId: "5e1d9ed9e0102e186cb33db8",
                name: this.Random.Generate(10),
                timezone: "Europe/Paris",
                profileIds: new[] { "5617b83de4b036e1c145279d", "5617b5bfe4b036e1c1452746" });
            var createdResponse = await client.Create(createApiUserCriteria: createApiUserCriteria);

            // Act
            var credential = await client.CreateCredentialsForApiUser(apiUserId: createdResponse.Id);

            // Assert
            Assert.NotNull(@object: credential);
        }

        #endregion Methods
    }
}
