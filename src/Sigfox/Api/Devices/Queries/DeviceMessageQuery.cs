namespace Sigfox.Api.Devices.Queries
{
    using System.Text;

    /// <summary>
    /// https://support.sigfox.com/apidocs#operation/getDeviceMessagesListForDevice
    /// </summary>
    public class DeviceMessageQuery
    {
        #region Properties

        public string Fields { get; set; }
        public long Since { get; set; }
        public long Before { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(value: $"since={this.Since}&before={this.Before}");

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
