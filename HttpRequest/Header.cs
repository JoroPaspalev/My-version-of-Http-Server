using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRequest
{
    public class Header
    {
        public Header(string headerAsString)
        {
            //content-length: 176
            string[] headerParts = headerAsString.Split(": ", StringSplitOptions.None);
            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
