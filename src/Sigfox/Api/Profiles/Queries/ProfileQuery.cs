namespace Sigfox.Api.Profiles.Queries
{
    using System.Text;

    public class ProfileQuery
    {
        #region Properties

        /// <summary>
        /// The group's identifier
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// also returns profiles inherited from parent's group
        /// </summary>
        public bool? Inherit { get; set; }

        /// <summary>
        ///  Enum:"group(name,type,level)" "roles(name,path(name))" 
        ///  Defines the other available fields to be returned in the response.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// The maximum number of items to return
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The number of items to skip
        /// </summary>
        public int? Offset { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(value: this.GroupId))
            {
                stringBuilder.Append(value: $"groupId={this.GroupId}");
            }

            if (this.Inherit.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"inherit={this.Inherit.GetValueOrDefault()}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Fields))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"fields={this.Fields}");
            }

            if (this.Limit.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"limit={this.Limit.GetValueOrDefault()}");
            }

            if (this.Offset.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"offset={this.Offset.GetValueOrDefault()}");
            }

            return stringBuilder.ToString();
        }

        #endregion Methods

        #region Private Methods

        private void AddAmpersandIfRequired(StringBuilder stringBuilder)
        {
            if (stringBuilder.Length == 0)
            {
                return;
            }
            else if (stringBuilder[stringBuilder.Length - 1] != '&')
            {
                stringBuilder.Append(value: "&");
            }
        }

        #endregion Private Methods
    }
}
