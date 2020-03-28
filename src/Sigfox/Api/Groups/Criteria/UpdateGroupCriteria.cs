namespace Sigfox.Api.Groups.Criteria
{
    using Enums;

    using ViewModels;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/updateGroup
    /// </summary>
    public class UpdateGroupCriteria
    {
        #region Constructor

        public UpdateGroupCriteria()
        {
        }

        public UpdateGroupCriteria(Group group)
        {
            this.Name = group.Name;
            this.Description = group.Description;
            this.Type = group.Type;
            this.Timezone = group.Timezone;
        }

        public UpdateGroupCriteria(string name, string description, GroupTypes type, string timezone)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Timezone = timezone;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The Group's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Group's Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Group's Type
        /// </summary>
        public GroupTypes Type { get; set; }

        /// <summary>
        /// The Group's Timezone (in Java TimeZone ID format, e.g."America/Costa_Rica").
        /// </summary>
        public string Timezone { get; set; }

        #endregion Properties
    }
}
