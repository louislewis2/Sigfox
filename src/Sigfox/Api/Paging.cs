namespace Sigfox.Api
{
    public class Paging
    {
        #region Constructor

        public Paging(string next)
        {
            this.Next = next;
        }

        #endregion Constructor

        #region Properties

        public string Next { get; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            if(string.IsNullOrWhiteSpace(value: this.Next))
            {
                return string.Empty;
            }

            var queryStringStartIndex = this.Next.IndexOf("?");

            if(queryStringStartIndex > 0)
            {
                return this.Next.Substring(startIndex: queryStringStartIndex + 1);
            }

            return string.Empty;
        }

        #endregion Methods
    }
}
