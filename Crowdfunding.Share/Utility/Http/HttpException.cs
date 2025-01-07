using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Share.Utility.Http
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
