namespace Sigfox.Api.Contracts.Queries
{
    using System.Text;

    public class ContractDevicesQuery
    {
        #region Properties

        /// <summary>
        /// Returns only devices of the given device type
        /// </summary>
        public string DeviceTypeId { get; set; }

        /// <summary>
        ///  Enum:"deviceType(name)" "group(name,type,level,bssId,customerBssId)" "contract(name)" "productCertificate(key)" "modemCertificate(name)" 
        ///  Defines the other available fields to be returned in the response.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// The maximum number of items to return
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Token representing the page to retrieve
        /// </summary>
        public string PageId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(value: this.DeviceTypeId))
            {
                stringBuilder.Append(value: $"deviceTypeId={this.DeviceTypeId}");
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
