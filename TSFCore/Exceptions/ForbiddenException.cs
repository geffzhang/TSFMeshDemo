using System;
using System.Net;

namespace TSF.Tracing.Propagation
{
    public class ForbiddenException : InvalidRestOperationException
    {
        #region Constructors

        public ForbiddenException(string message, int customErrorCode, Exception innerException = null)
            : base(message, customErrorCode, innerException) { }

        #endregion

        #region Properties

        public override int ResponseCode => (int) HttpStatusCode.Forbidden;

        #endregion
    }
}