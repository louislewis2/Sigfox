namespace Sigfox.Api.Contracts.Queries
{
    using System;
    using System.Text;

    using Enums;
    using Groups.Enums;

    public class ContractQuery
    {
        #region Fields

        private int? groupType;
        private int? pricingModel;
        private int? subscriptionPlan;
        private int? geoLocationMode;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Searches for contracts containing the given text in their name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Searches for contracts who are attached to the given group
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Searches for contracts that are attached to a specific group type.
        /// </summary>
        public GroupTypes GroupType
        {
            set
            {
                this.groupType = (int)value;
            }
            get
            {
                return (GroupTypes)this.groupType.GetValueOrDefault();
            }
        }

        /// <summary>
        /// Searches for contracts that are attached to the given group and its descendants
        /// </summary>
        public bool? Deep { get; set; }

        /// <summary>
        /// Searches for contracts that are attached to the given group and its ancestors
        /// </summary>
        public bool? Up { get; set; }

        /// <summary>
        /// Searches for contracts with the listed orderIds
        /// </summary>
        public string[] OrderIds { get; set; }

        /// <summary>
        /// Searches for contracts IDs that have the listed external (BSS) contractId
        /// </summary>
        public string[] ContractIds { get; set; }

        /// <summary>
        /// Searches for contracts with communication end time superior or equal to given time (in milliseconds since Unix Epoch).
        /// </summary>
        public long? FromTime { get; set; }

        /// <summary>
        /// Searches for contracts with start time inferior to given time (in milliseconds since Unix Epoch).
        /// </summary>
        public long? ToTime { get; set; }

        /// <summary>
        /// Searches for contracts with the given token duration in months.
        /// </summary>
        public int? TokenDuration { get; set; }

        /// <summary>
        /// Searches for contracts with a given pricing model
        /// </summary>
        public PricingModelTypes PricingModel
        {
            set
            {
                this.pricingModel = (int)value;
            }
            get
            {
                return (PricingModelTypes)this.pricingModel.GetValueOrDefault();
            }
        }

        /// <summary>
        /// Searches for contracts with the given subscription plan
        /// </summary>
        public SubscriptionPlanTypes SubscriptionPlan
        {
            set
            {
                this.subscriptionPlan = (int)value;
            }
            get
            {
                return (SubscriptionPlanTypes)this.subscriptionPlan.GetValueOrDefault();
            }
        }

        /// <summary>
        /// Searches for contracts with the given geolocation mode
        /// </summary>
        public GeoLocationModeTypes GeoLocationMode
        {
            set
            {
                this.geoLocationMode = (int)value;
            }
            get
            {
                return (GeoLocationModeTypes)this.geoLocationMode.GetValueOrDefault();
            }
        }

        /// <summary>
        ///  Enum:"group(name,type,level)" "order(name)" "blacklistedTerritories(group(name,type,level))"
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

        /// <summary>
        /// Token representing the page to retrieve
        /// </summary>
        public string PageId { get; set; }

        /// <summary>
        /// if true, we return the list of actions and resources the user has access
        /// </summary>
        public bool? Authorizations { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(value: this.Name))
            {
                stringBuilder.Append(value: $"name={this.Name}");
            }

            if (!string.IsNullOrWhiteSpace(value: this.GroupId))
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"groupId={this.GroupId}");
            }

            if (this.groupType.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"groupType={this.groupType.GetValueOrDefault()}");
            }

            if (this.Deep.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"deep={this.Deep.GetValueOrDefault()}");
            }

            if (this.Up.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"up={this.Up.GetValueOrDefault()}");
            }

            if (!this.OrderIds.IsNullOrEmpty())
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"orderIds={string.Join(",", this.OrderIds)}");
            }

            if (!this.ContractIds.IsNullOrEmpty())
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"contractIds={string.Join(",", this.ContractIds)}");
            }

            if (this.FromTime.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"fromTime={this.FromTime.GetValueOrDefault()}");
            }

            if (this.ToTime.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"toTime={this.ToTime.GetValueOrDefault()}");
            }

            if (this.TokenDuration.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"tokenDuration={this.TokenDuration.GetValueOrDefault()}");
            }

            if (this.pricingModel.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"pricingModel={this.pricingModel.GetValueOrDefault()}");
            }

            if (this.subscriptionPlan.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"subscriptionPlan={this.subscriptionPlan.GetValueOrDefault()}");
            }

            if (this.geoLocationMode.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"geolocationMode={this.geoLocationMode.GetValueOrDefault()}");
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

            if (this.Authorizations.HasValue)
            {
                this.AddAmpersandIfRequired(stringBuilder: stringBuilder);

                stringBuilder.Append(value: $"authorizations={this.Authorizations.GetValueOrDefault()}");
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
