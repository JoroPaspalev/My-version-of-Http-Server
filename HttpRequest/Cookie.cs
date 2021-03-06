﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRequest
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Cookie(string cookieAsString)
        {
            string[] cookieParts = cookieAsString.Split("=", StringSplitOptions.None);
            this.Name = cookieParts[0];
            this.Value = cookieParts[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
