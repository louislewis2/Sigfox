namespace Sigfox.Api.Errors
{
    public class ErrorResponse
    {
        #region Properties

        public string Message { get; set; }
        public ErrorEntry[] Errors { get; set; }

        #endregion Properties
    }
}
