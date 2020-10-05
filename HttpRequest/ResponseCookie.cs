using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRequest
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value)
            :base(name, value)
        {
        }
    }
}
