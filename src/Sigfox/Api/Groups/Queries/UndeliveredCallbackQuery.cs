namespace Sigfox.Api.Groups.Queries
{
    using System.Text;

    public class UndeliveredCallbackQuery
    {
        #region Properties

        public long? Since { get; set; }
        public long? Before { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string PageId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (this.Since.HasValue)
            {
                stringBuilder.Append(value: $"since={this.Since.GetValueOrDefault()}");
            }

            if (this.Before.HasValue)
            {
                stringBuilder.Append(value: $"before={this.Before.GetValueOrDefault()}");
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
