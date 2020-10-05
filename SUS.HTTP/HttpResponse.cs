using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body == null)
            {
                //throw new ArgumentException("Body can not be null");
                this.Body = new byte[0];
            }
            else
            {
                this.Body = body;
            }

            this.Cookies = new List<ResponseCookie>();
            this.Headers = new List<Header>();
            this.Headers.Add(new Header("Content-Type", contentType));
            this.Headers.Add(new Header("Content-length", this.Body.Length.ToString()));
            this.HttpStatusCode = statusCode;
        }


        public ICollection<Header> Headers { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public ICollection<ResponseCookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {(int)this.HttpStatusCode} {this.HttpStatusCode}" + HttpConstants.NEW_LINE);

            foreach (var header in this.Headers)
            {
                sb.Append(header.ToString() + HttpConstants.NEW_LINE);
            }

            foreach (var cookie in this.Cookies)
            {
                sb.Append($"Set-Cookie: {cookie}" + HttpConstants.NEW_LINE);
            }

            sb.Append(HttpConstants.NEW_LINE);

            return sb.ToString();
        }
    }
}
