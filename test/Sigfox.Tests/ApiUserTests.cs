namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.ApiUsers.Queries;

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

        #endregion Methods
    }
}
