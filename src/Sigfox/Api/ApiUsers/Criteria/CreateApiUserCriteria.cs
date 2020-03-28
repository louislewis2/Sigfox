namespace Sigfox.Api.ApiUsers.Criteria
{
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/createApiUser
    /// </summary>
    public class CreateApiUserCriteria
    {
        #region Constructor

        public CreateApiUserCriteria()
        {
        }

        public CreateApiUserCriteria(string groupId, string name, string timezone, IEnumerable<string> profileIds)
        {
            this.GroupId = groupId;
            this.Name = name;
            this.Timezone = timezone;

            if (profileIds != null)
            {
                this.ProfileIds = profileIds.ToArray();
            }
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The group identifer
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// The Group's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The API user timezone as a Java TimeZone ID ("full name" version only, like "America/Costa_Rica")
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// The API user profiles
        /// </summary>
        public string[] ProfileIds { get; set; }

        #endregion Properties
    }
}
