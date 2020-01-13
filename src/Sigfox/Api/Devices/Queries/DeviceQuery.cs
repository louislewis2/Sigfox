namespace Sigfox.Api.Devices.Queries
{
    using System;
    using System.Text;

    public class DeviceQuery
    {
        #region Properties

        public string Id { get; set; }
        public string[] GroupIds { get; set; }
        public bool? Deep { get; set; }
        public string DeviceTypeId { get; set; }
        public string OperatorId { get; set; }
        public string Sort { get; set; }
        public string MinId { get; set; }
        public string MaxId { get; set; }
        public string Fields { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string PageId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if(!string.IsNullOrWhiteSpace(value: this.Id))
            {
                stringBuilder.Append(value: $"id={this.Id}");
            }

            if(!this.GroupIds.IsNullOrEmpty())
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"groupIds={string.Join(",", this.GroupIds)}");
            }

            if(this.Deep.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"deep={this.Deep.GetValueOrDefault()}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.DeviceTypeId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"deviceTypeId={this.DeviceTypeId}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.OperatorId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"operatorId={this.OperatorId}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Sort))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"sort={this.Sort}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.MinId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"minId={this.MinId}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.MaxId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"maxId={this.MaxId}");
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
            if(stringBuilder.Length == 0)
            {
                return;
            }
            else if(stringBuilder[stringBuilder.Length - 1] != '&')
            {
                stringBuilder.Append(value: "&");
            }
        }

        #endregion Private Methods
    }
}
