namespace Sigfox.Api.Contracts.ViewModels
{
    using Newtonsoft.Json;

    using Enums;
    using Groups.ViewModels;

    public class Contract
    {
        #region Constructor

        public Contract(string name,
                        long activationEndTime,
                        long communicationEndTime,
                        bool isBiDirectional,
                        bool highPriorityDownlink,
                        int maxUplinkFrames,
                        int maxDownlinkFrames,
                        int maxTokens,
                        bool automaticRenewal,
                        int renewalDuration,
                        Option[] options,
                        string id,
                        string contractId,
                        string userId,
                        MinimalGroup group,
                        MinimalContractInformation order,
                        PricingModelTypes pricingModel,
                        string createdBy,
                        long lastEditionTime,
                        long creationTime,
                        string lastEditedBy,
                        long startTime,
                        string timezone,
                        SubscriptionPlanTypes subscriptionPlan,
                        int tokenDuration,
                        MinimalGroup[] blacklistedTerritories,
                        int tokensInUse,
                        int tokensUsed)
        {
            this.Name = name;
            this.ActivationEndTime = activationEndTime;
            this.CommunicationEndTime = communicationEndTime;
            this.IsBiDirectional = isBiDirectional;
            this.HighPriorityDownlink = highPriorityDownlink;
            this.MaxUplinkFrames = maxUplinkFrames;
            this.MaxDownlinkFrames = maxDownlinkFrames;
            this.MaxTokens = maxTokens;
            this.AutomaticRenewal = automaticRenewal;
            this.RenewalDuration = renewalDuration;
            this.Options = options;
            this.Id = id;
            this.ContractId = contractId;
            this.UserId = userId;
            this.Group = group;
            this.Order = order;
            this.PricingModel = pricingModel;
            this.CreatedBy = createdBy;
            this.LastEditionTime = lastEditionTime;
            this.CreationTime = creationTime;
            this.LastEditedBy = lastEditedBy;
            this.StartTime = startTime;
            this.Timezone = timezone;
            this.SubscriptionPlan = subscriptionPlan;
            this.TokenDuration = tokenDuration;
            this.BlacklistedTerritories = blacklistedTerritories;
            this.TokensInUse = tokensInUse;
            this.TokensUsed = tokensUsed;
        }

        #endregion Constructor

        #region Properties

        public string Name { get; }
        public long ActivationEndTime { get; }
        public long CommunicationEndTime { get; }

        [JsonProperty("bidir")]
        public bool IsBiDirectional { get; }

        public bool HighPriorityDownlink { get; }
        public int MaxUplinkFrames { get; }
        public int MaxDownlinkFrames { get; }
        public int MaxTokens { get; }
        public bool AutomaticRenewal { get; }
        public int RenewalDuration { get; }
        public Option[] Options { get; }
        public string Id { get; }
        public string ContractId { get; }
        public string UserId { get; }
        public MinimalGroup Group { get; }
        public MinimalContractInformation Order { get; }
        public PricingModelTypes PricingModel { get; }
        public string CreatedBy { get; }
        public long LastEditionTime { get; }
        public long CreationTime { get; }
        public string LastEditedBy { get; }
        public long StartTime { get; }
        public string Timezone { get; }
        public SubscriptionPlanTypes SubscriptionPlan { get; }
        public int TokenDuration { get; }
        public MinimalGroup[] BlacklistedTerritories { get; }
        public int TokensInUse { get; }
        public int TokensUsed { get; }

        #endregion Properties
    }
}
