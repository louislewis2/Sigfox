namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.Users.Queries;

    public class UserTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Get_Users_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act
            var usersPagedResponse = await client.GetUsers();

            // Assert
            Assert.NotNull(@object: usersPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Users_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var userQuery = new UserQuery { Limit = 1 };

            // Act
            var usersPagedResponse = await client.GetUsers(userQuery: userQuery);

            // Assert
            Assert.NotNull(@object: usersPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Users_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var userQuery = new UserQuery { Limit = 1 };

            // Act
            var usersPagedResponse1 = await client.GetUsers(userQuery: userQuery);
            var usersPagedResponse2 = await client.GetUsers(paging: usersPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: usersPagedResponse1);
            Assert.NotNull(@object: usersPagedResponse2);
        }

        [Fact]
        public async Task Can_Get_Users_With_Limit_And_Id()
        {
            // Arrange
            var client = this.GetClient();
            var usersPagedResponse = await client.GetUsers();
            var userQuery = new UserQuery { Limit = 2, Text = usersPagedResponse.Data.First().FirstName };

            // Act
            var usersPagedResponse2 = await client.GetUsers(userQuery: userQuery);

            // Assert
            Assert.NotNull(@object: usersPagedResponse2);
            Assert.Single(collection: usersPagedResponse2.Data);
            Assert.Equal(expected: usersPagedResponse.Data.First().FirstName, actual: usersPagedResponse2.Data.First().FirstName);
        }

        #endregion Methods
    }
}
