namespace Sigfox.Api.ApiUsers.Criteria
{
    using System.Linq;
    using System.Collections.Generic;

    using ViewModels;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/updateApiUser
    /// </summary>
    public class UpdateApiUserCriteria
    {
        #region Constructor

        public UpdateApiUserCriteria()
        {
            this.ProfileIds = new List<string>();
        }

        public UpdateApiUserCriteria(ApiUser apiUser)
        {
            this.Name = apiUser.Name;
            this.Timezone = apiUser.Timezone;

            if (apiUser.Profiles != null)
            {
                this.ProfileIds = apiUser.Profiles.Select(x => x.Id).ToList();
            }
        }

        public UpdateApiUserCriteria(string name, string timezone, string[] profileIds)
        {
            this.Name = name;
            this.Timezone = timezone;

            if (profileIds != null)
            {
                this.ProfileIds = profileIds.ToList();
            }
        }

        #endregion Constructor

        #region Properties

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
        public List<string> ProfileIds { get; set; }

        #endregion Properties
    }
}
