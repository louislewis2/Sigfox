namespace Sigfox.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;

    using Sigfox.Api.Groups.Queries;
    using Sigfox.Api.Groups.Criteria;
    using Sigfox.Api.Groups.Enums;

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
                name: "Test Group",
                description: "Test Group Description",
                type: GroupTypes.Channel,
                timezone: "Europe/Paris",
                parentId: "",
                networkOperatorId: ""
                );

            // Act
            var createdResponse = await client.Create(createGroupCriteria: createGroupCriteria);

            // Assert
            Assert.NotNull(@object: createdResponse);
        }

        #endregion Methods
    }
}
