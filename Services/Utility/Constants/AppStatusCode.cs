using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Utilities.Constants
{
    public static class AppStatusCode
    {
        public const int OK = (int)HttpStatusCode.OK;
        public const int NotFound = (int)HttpStatusCode.NotFound;
        public const int Unauthorized = (int)HttpStatusCode.Unauthorized;
        public const int BadRequest = (int)HttpStatusCode.BadRequest;
        public const int Forbidden = (int)HttpStatusCode.Forbidden;
    }
}
