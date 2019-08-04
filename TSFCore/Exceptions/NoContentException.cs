using System;
using System.Net;

namespace TSF.Tracing.Propagation
{
    public class NoContentException : InvalidRestOperationException
    {
        #region Constructors

        public NoContentException(string message, int customErrorCode, Exception innerException = null)
            : base(message, customErrorCode, innerException) { }

        #endregion

        #region Properties

        #region Overrides of InvalidRestOperationException

        public override int ResponseCode => (int) HttpStatusCode.NoContent;

        #endregion

        #endregion
    }
}