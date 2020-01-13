namespace Sigfox.Api
{
    public class PagedResponse<T>
    {
        #region Constructor

        public PagedResponse(T[] data, Paging paging)
        {
            this.Data = data;
            this.Paging = paging;
        }

        #endregion Constructor

        #region Properties

        public T[] Data { get; }
        public Paging Paging { get; }

        #endregion Properties
    }
}
