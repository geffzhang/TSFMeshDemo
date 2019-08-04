using System;

namespace TSF.Tracing.Propagation
{
    public class UnsupportedMediaTypeException : InvalidRestOperationException
    {
        public UnsupportedMediaTypeException(string message, int customErrorCode, Exception innerException = null)
            : base(message, customErrorCode, innerException) { }

        public override int ResponseCode => 415;
    }
}