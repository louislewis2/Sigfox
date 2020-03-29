namespace Sigfox.Api.DeviceTypes.ViewModels
{
    using Enums;
    using Shared.Enums;
    using Groups.ViewModels;
    using Contracts.ViewModels;

    public class DeviceType
    {
        #region Constructor

        public DeviceType(string name,
                          string description,
                          DownlinkModeTypes downlinkMode,
                          string downlinkDataString,
                          PayloadTypes payloadType,
                          string payloadConfig,
                          long keepAlive,
                          string alertEmail,
                          bool automaticRenewal,
                          string id,
                          MinimalGroup group,
                          MinimalContractInformation contract,
                          MinimalContractInformation[] contracts,
                          MinimalContractInformation[] detachedContracts,
                          GeoLocationPayloadConfig geolocPayloadConfig,
                          long creationTime,
                          string createdBy,
                          long lastEditionTime,
                          string lastEditedBy)
        {
            this.Name = name;
            this.Description = description;
            this.DownlinkMode = downlinkMode;
            this.DownlinkDataString = downlinkDataString;
            this.PayloadType = payloadType;
            this.PayloadConfig = payloadConfig;
            this.KeepAlive = keepAlive;
            this.AlertEmail = alertEmail;
            this.AutomaticRenewal = automaticRenewal;
            this.Id = id;
            this.Group = group;
            this.Contract = contract;
            this.Contracts = contracts;
            this.DetachedContracts = detachedContracts;
            this.GeolocPayloadConfig = geolocPayloadConfig;
            this.CreationTime = creationTime;
            this.CreatedBy = createdBy;
            this.LastEditionTime = lastEditionTime;
            this.LastEditedBy = lastEditedBy;
        }

        #endregion Constructor

        #region Properties

        public string Name { get; }
        public string Description { get; }
        public DownlinkModeTypes DownlinkMode { get; }
        public string DownlinkDataString { get; }
        public PayloadTypes PayloadType { get; }
        public string PayloadConfig { get; }
        public long KeepAlive { get; }
        public string AlertEmail { get; }
        public bool AutomaticRenewal { get; }
        public string Id { get; }
        public MinimalGroup Group { get; }
        public MinimalContractInformation Contract { get; }
        public MinimalContractInformation[] Contracts { get; }
        public MinimalContractInformation[] DetachedContracts { get; }
        public GeoLocationPayloadConfig GeolocPayloadConfig { get; }
        public long CreationTime { get; }
        public string CreatedBy { get; }
        public long LastEditionTime { get; }
        public string LastEditedBy { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods
    }
}
