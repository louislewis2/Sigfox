namespace Sigfox.Api.Devices.ViewModels
{
    public class MinimalBaseStation
    {
        #region Properties

        /// <summary>
        /// The base station identifier in hexadecimal
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The base station name
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}
