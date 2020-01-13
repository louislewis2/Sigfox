namespace Sigfox.Api.DeviceTypes.Queries
{
    using System;
    using System.Text;

    using Shared.Enums;

    public class DeviceTypeQuery
    {
        #region Fields

        private int? payloadType;

        #endregion Fields

        #region Properties

        public string Name { get; set; }
        public string[] GroupIds { get; set; }
        public bool? Deep { get; set; }
        public string ContractId { get; set; }
        public PayloadTypes PayloadType
        {
            set
            {
                this.payloadType = (int)value;
            }
            get
            {
                return (PayloadTypes)this.payloadType.GetValueOrDefault();
            }
        }
        public string Sort { get; set; }
        public string Fields { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string PageId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(value: this.Name))
            {
                stringBuilder.Append(value: $"name={this.Name}");
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

            if (!string.IsNullOrWhiteSpace(value: this.ContractId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"contractId={this.ContractId}");
            }

            if (this.payloadType.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"payloadType={this.payloadType.GetValueOrDefault()}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.Sort))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"sort={this.Sort}");
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
