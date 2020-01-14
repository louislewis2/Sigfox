namespace Sigfox.Api.Groups.Criteria
{
    using Enums;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/createGroup
    /// </summary>
    public class CreateGroupCriteria
    {
        #region Constructor

        public CreateGroupCriteria()
        {
        }

        public CreateGroupCriteria(string name, string description, GroupTypes type, string timezone, string parentId, string networkOperatorId)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Timezone = timezone;
            this.ParentId = parentId;
            this.NetworkOperatorId = networkOperatorId;
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

        /// <summary>
        /// The Parent Group Id
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// SNO or NIP Group Id For A DIST & SVNO Group. This Field Is Mandatory For DIST & SVNO Group Creation.
        /// </summary>
        public string NetworkOperatorId { get; set; }

        #endregion Properties
    }
}
