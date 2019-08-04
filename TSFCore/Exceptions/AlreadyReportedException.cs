using System;

namespace TSF.Tracing.Propagation
{
    public class AlreadyReportedException : InvalidRestOperationException
    {
        public AlreadyReportedException(string message, int customErrorCode, Exception innerException = null)
            : base(message, customErrorCode, innerException) { }

        public override int ResponseCode => 208;
    }
}