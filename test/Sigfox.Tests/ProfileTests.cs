namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Exceptions;
    using Sigfox.Api.Profiles.Queries;

    public class ProfileTests : TestBase
    {
        #region Methods

        [Fact]
        public async Task Can_Fail_Get_Profiles_Without_Parameters()
        {
            // Arrange
            var client = this.GetClient();

            // Act & Assert
            await Assert.ThrowsAsync<IntegrationException>(async () =>
               {
                   await client.GetProfiles();
               });
        }

        [Fact]
        public async Task Can_Get_Profiles_With_GroupId()
        {
            // Arrange
            var client = this.GetClient();
            var groups = await client.GetGroups();
            var profileQuery = new ProfileQuery { GroupId = groups.Data.First().Id };

            // Act
            var profilesPagedResponse = await client.GetProfiles(profileQuery: profileQuery);

            // Assert
            Assert.NotNull(@object: profilesPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Profiles_With_Limit()
        {
            // Arrange
            var client = this.GetClient();
            var groups = await client.GetGroups();
            var profileQuery = new ProfileQuery { Limit = 1, GroupId = groups.Data.First().Id };

            // Act
            var profilesPagedResponse = await client.GetProfiles(profileQuery: profileQuery);

            // Assert
            Assert.NotNull(@object: profilesPagedResponse);
        }

        [Fact]
        public async Task Can_Get_Profiles_Next_Page_With_Paging()
        {
            // Arrange
            var client = this.GetClient();
            var groups = await client.GetGroups();
            var profileQuery = new ProfileQuery { Limit = 1, GroupId = groups.Data.First().Id };

            // Act
            var profilesPagedResponse1 = await client.GetProfiles(profileQuery: profileQuery);
            var profilesPagedResponse2 = await client.GetProfiles(paging: profilesPagedResponse1.Paging);

            // Assert
            Assert.NotNull(@object: profilesPagedResponse1);
            Assert.NotNull(@object: profilesPagedResponse2);
        }

        #endregion Methods
    }
}
