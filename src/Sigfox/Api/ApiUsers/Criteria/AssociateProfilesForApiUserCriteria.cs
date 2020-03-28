namespace Sigfox.Api.ApiUsers.Criteria
{
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/addProfileToApiUser
    /// </summary>
    public class AssociateProfilesForApiUserCriteria
    {
        #region Constructor

        public AssociateProfilesForApiUserCriteria()
        {
        }

        public AssociateProfilesForApiUserCriteria(IEnumerable<string> profileIds)
        {
            if (profileIds != null)
            {
                this.ProfileIds = profileIds.ToArray();
            }
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The API user profiles
        /// </summary>
        public string[] ProfileIds { get; set; }

        #endregion Properties
    }
}
