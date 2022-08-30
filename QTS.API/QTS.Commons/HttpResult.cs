using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTS.Commons
{
    public class HttpResult
    {
        public MessageCode messageCode { get; set; }
        public string message { get; set; }
        public object content { get; set; }
        public HttpResult()
        {

        }
        public HttpResult(MessageCode messageCode)
        {
            this.messageCode = messageCode;
        }
        public HttpResult(MessageCode messageCode,string message)
        {
            this.messageCode = messageCode;
            this.message = message;
        }
        public HttpResult(MessageCode messageCode, string message, object content)
        {
            this.messageCode = messageCode;
            this.message = message;
            this.content = content;
        }
        
    }
    public enum MessageCode
    {
        Success=200,
        NotFound=404,
        Error
    }
}
