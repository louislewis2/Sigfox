namespace Sigfox.Api.Groups.ViewModels
{
    using Enums;

    public class Group
    {
        #region Constructor

        public Group(string name, string description, GroupTypes type, string timezone, string id, string nameCI, Path[] path, string networkOperatorId)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Timezone = timezone;
            this.Id = id;
            this.NameCI = nameCI;
            this.Path = path;
            this.NetworkOperatorId = networkOperatorId;
        }

        #endregion Constructor

        #region Properties

        public string Name { get; }
        public string Description { get; }
        public GroupTypes Type { get; }
        public string Timezone { get; }
        public string Id { get; }
        public string NameCI { get; }
        public Path[] Path { get; }
        public string NetworkOperatorId { get; }

        #endregion Properties
    }
}
