using System;

namespace TSF.Tracing.Propagation
{
    public class UnprocessableEntityException : InvalidRestOperationException
    {
        #region Constructors

        public UnprocessableEntityException(string message, int customErrorCode, Exception innerException = null)
            : base(message, customErrorCode, innerException) { }

        #endregion

        #region Properties

        public override int ResponseCode => 422;

        #endregion
    }
}