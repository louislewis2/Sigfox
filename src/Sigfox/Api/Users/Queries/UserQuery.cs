namespace Sigfox.Api.Users.Queries
{
    using System;
    using System.Text;

    public class UserQuery
    {
        #region Properties

        public string Fields { get; set; }
        public string Text { get; set; }
        public string ProfileId { get; set; }
        public string[] GroupIds { get; set; }
        public bool? Deep { get; set; }
        public string Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string PageId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(value: this.Fields))
            {
                stringBuilder.Append(value: $"fields={this.Fields}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Text))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"text={this.Text}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.ProfileId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"profileId={this.ProfileId}");
            }

            if (!this.GroupIds.IsNullOrEmpty())
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"groupIds={string.Join(",", this.GroupIds)}");
            }

            if (this.Deep.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"deep={this.Deep.GetValueOrDefault()}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Sort))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"sort={this.Sort}");
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

            if (!string.IsNullOrWhiteSpace(value: this.PageId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"pageId={this.PageId}");
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
