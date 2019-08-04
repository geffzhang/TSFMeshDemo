using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSF.Tracing.Propagation
{
    public class ErrorDetails
    {
        public int ErrorCode { get; set; }

        public string ErrorReason { get; set; }

        public ErrorDetails(InvalidRestOperationException ex)
        {
            ErrorCode = ex.CustomErrorCode;
            ErrorReason = ex.Message;
        }

        public ErrorDetails() { }
    }
}
