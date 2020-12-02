using System;
using System.Collections.Generic;
using System.Text;

namespace Security
{
    public class UserFriendlyException : Exception
    {
        public int Code { get; set; }
        public string Message { get; }
        public Int32 Severity { get; set; }

        public UserFriendlyException(int code, string details)
        {
            this.Code = Code;
            this.Message = Message;
            this.Severity = 0;
        }
    }
}
