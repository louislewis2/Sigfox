namespace Sigfox.Api
{
    public class ArrayResponse<T>
    {
        #region Constructor

        public ArrayResponse(T[] data)
        {
            this.Data = data;
        }

        #endregion Constructor

        #region Properties

        public T[] Data { get; }

        #endregion Properties
    }
}
