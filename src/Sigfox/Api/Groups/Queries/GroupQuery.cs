namespace Sigfox.Api.Groups.Queries
{
    using System;
    using System.Linq;
    using System.Text;

    using Enums;

    public class GroupQuery
    {
        #region Properties

        public string[] ParentIds { get; set; }
        public bool? Deep { get; set; }
        public string Name { get; set; }
        public GroupTypes[] Types { get; set; }
        public string Fields { get; set; }
        public string Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string PageId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (!this.ParentIds.IsNullOrEmpty())
            {
                stringBuilder.Append(value: $"parentIds={string.Join(",", this.ParentIds)}");
            }

            if (this.Deep.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"deep={this.Deep.GetValueOrDefault()}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Name))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"name={this.Name}");
            }

            if (!this.Types.IsNullOrEmpty())
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"types={string.Join(",", this.Types.Select(x => (int)x))}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Fields))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"fields={this.Fields}");
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
