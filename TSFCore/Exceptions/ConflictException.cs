using System;
using System.Net;

namespace TSF.Tracing.Propagation
{
    public class ConflictException : InvalidRestOperationException
    {
        #region Constructors

        public ConflictException(string message, int customErrorCode, Exception innerException = null)
            : base(message, customErrorCode, innerException) { }

        #endregion

        #region Properties

        public override int ResponseCode => (int) HttpStatusCode.Conflict;

        #endregion
    }
}