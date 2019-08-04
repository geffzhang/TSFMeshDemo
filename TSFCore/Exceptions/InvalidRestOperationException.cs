using System;

namespace TSF.Tracing.Propagation
{
    public abstract class InvalidRestOperationException : InvalidOperationException
    {
        #region Constructors

        protected InvalidRestOperationException(string message, int customErrorCode, Exception innerException = null)
            : base(message, innerException)
        {
            CustomErrorCode = customErrorCode;
        }

        #endregion

        #region Properties

        public abstract int  ResponseCode    { get; }

        public int CustomErrorCode { get; }

        #endregion
    }
}