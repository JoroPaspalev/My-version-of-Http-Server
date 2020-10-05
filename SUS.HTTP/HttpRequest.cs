using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestAsString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            HttpParser(requestAsString);
        }

        private void HttpParser(string request)
        {
            string[] requestParts = request.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

            string headLineAndHeaders = requestParts[0];
            if (requestParts.Length > 1)
            {
                string body = requestParts[1];
                this.Body = body;
            }

            string[] headerParts = headLineAndHeaders.Split(new string[] { "\r\n" }, 2, StringSplitOptions.None);
            string headLine = headerParts[0];
            string headers = headerParts[1];

            HeadLineParser(headLine);
            HeadersParser(headers);

            if (this.Headers.Any(h => h.Name == "Cookie"))
            {
                string cookies = this.Headers.First(h => h.Name == "Cookie").Value;
                CookieParser(cookies);
            }
        }

        private void HeadLineParser(string headLine)
        {
            //GET /users/profile/show/joro_paspalev HTTP/1.1

            string[] headLineParts = headLine.Split(' ');

            HttpMethod method;
            bool isParsedMethod = Enum.TryParse(headLineParts[0], out method);

            try
            {
                if (isParsedMethod)
                {
                    this.Method = method;
                }
                else
                {
                    throw new ArgumentException("Http method is not in valid format!");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            this.Path = headLineParts[1];
            this.HttpVersion = headLineParts[2];
        }

        private void HeadersParser(string headers)
        {
            string[] allHeaders = headers.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (var header in allHeaders)
            {
                Header currHeader = new Header(header);
                this.Headers.Add(currHeader);
            }
        }

        private void CookieParser(string cookies)
        {
            // _ga=GA1.2.771947856.1559822829; fbp=fb.1.1591281385933.1246513774; .auth.softuni=QfwKkoffYStU2baq9cfiz2jhL
            string[] allCookies = cookies.Split(new string[] { "; " }, StringSplitOptions.None);

            foreach (var cookie in allCookies)
            {
                var currCookie = new Cookie(cookie);
                this.Cookies.Add(currCookie);
            }
        }

        public HttpMethod Method { get; set; }

        public string Path { get; set; }

        public string HttpVersion { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("HttpRequest Contains:");
            sb.AppendLine($"Method: {this.Method}, Path: {this.Path} and Version: {this.HttpVersion}");
            foreach (var header in this.Headers)
            {
                sb.AppendLine($"{header.Name}: {header.Value}");
            }
            sb.AppendLine(this.Body);

            return sb.ToString().TrimEnd();
        }
    }
}

