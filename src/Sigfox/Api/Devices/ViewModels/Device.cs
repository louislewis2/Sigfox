namespace Sigfox.Api.Devices.ViewModels
{
    using Enums;
    using Groups.ViewModels;
    using Contracts.ViewModels;
    using DeviceTypes.ViewModels;

    public class Device
    {
        #region Constructor

        public Device(string id,
                      string name,
                      MinimalDeviceType deviceType,
                      MinimalContractInformation contract,
                      MinimalGroup group,
                      Certificate modemCertificate,
                      bool prototype,
                      Certificate productCertificate,
                      Location location,
                      ComputedLocation lastComputedLocation,
                      string pac,
                      int sequenceNumber,
                      int trashSequenceNumber,
                      long lastCom,
                      LinkQualityIndicatorTypes lqi,
                      long activationTime,
                      long creationTime,
                      DeviceStateTypes comState,
                      Token token,
                      long unsubscriptionTime,
                      string createdBy,
                      long lastEditionTime,
                      string lastEditedBy,
                      bool automaticRenewal,
                      AutomaticRenewalStatusTypes automaticRenewalStatus,
                      bool activable)
        {
            this.Id = id;
            this.Name = name;
            this.DeviceType = deviceType;
            this.Contract = contract;
            this.Group = group;
            this.ModemCertificate = modemCertificate;
            this.Prototype = prototype;
            this.ProductCertificate = productCertificate;
            this.Location = location;
            this.LastComputedLocation = lastComputedLocation;
            this.Pac = pac;
            this.SequenceNumber = sequenceNumber;
            this.TrashSequenceNumber = trashSequenceNumber;
            this.LastCom = lastCom;
            this.Lqi = lqi;
            this.ActivationTime = activationTime;
            this.CreationTime = creationTime;
            this.ComState = comState;
            this.Token = token;
            this.UnsubscriptionTime = unsubscriptionTime;
            this.CreatedBy = createdBy;
            this.LastEditionTime = lastEditionTime;
            this.LastEditedBy = lastEditedBy;
            this.AutomaticRenewal = automaticRenewal;
            this.AutomaticRenewalStatus = automaticRenewalStatus;
            this.Activable = activable;
        }

        #endregion Constructor

        #region Properties

        public string Id { get; }
        public string Name { get; }
        public MinimalDeviceType DeviceType { get; }
        public MinimalContractInformation Contract { get; }
        public MinimalGroup Group { get; }
        public Certificate ModemCertificate { get; }
        public bool Prototype { get; }
        public Certificate ProductCertificate { get; }
        public Location Location { get; }
        public ComputedLocation LastComputedLocation { get; }
        public string Pac { get; }
        public int SequenceNumber { get; }
        public int TrashSequenceNumber { get; }
        public long LastCom { get; }
        public LinkQualityIndicatorTypes Lqi { get; }
        public long ActivationTime { get; }
        public long CreationTime { get; }
        public DeviceStateTypes ComState { get; }
        public Token Token { get; }
        public long UnsubscriptionTime { get; }
        public string CreatedBy { get; }
        public long LastEditionTime { get; }
        public string LastEditedBy { get; }
        public bool AutomaticRenewal { get; }
        public AutomaticRenewalStatusTypes AutomaticRenewalStatus { get; }
        public bool Activable { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"{this.Name}";
        }

        #endregion Methods
    }
}
