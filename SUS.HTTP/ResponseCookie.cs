using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value)
            :base(name, value)
        {
        }

        //attributes of a this.cookie
        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name}={this.Value}");

            if (this.MaxAge > 0 )
            {
                sb.Append($"; Max-Age={this.MaxAge}");
            }

            if (this.HttpOnly == true)
            {
                sb.Append($"; HttpOnly");
            }

            if (this.Path != null)
            {
                sb.Append($"; Path={this.Path}");
            }

            return sb.ToString();
        }
    }
}
