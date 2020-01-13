namespace Sigfox.Api.Devices.ViewModels
{
    using Enums;

    public class Token
    {
        #region Constructor

        public Token(TokenStateTypes state, string detailMessage, long end, int freeMessages, int freeMessagesSent)
        {
            this.State = state;
            this.DetailMessage = detailMessage;
            this.End = end;
            this.FreeMessages = freeMessages;
            this.FreeMessagesSent = freeMessagesSent;
        }

        #endregion Constructor

        #region Properties

        public TokenStateTypes State { get; }
        public string DetailMessage { get; }
        public long End { get; }
        public int FreeMessages { get; }
        public int FreeMessagesSent { get; }

        #endregion Properties
    }
}
