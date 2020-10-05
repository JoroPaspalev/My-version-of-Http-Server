using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpRequest
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
            string[] requestParts = request.Split("\r\n\r\n");

            string headLineAndHeaders = requestParts[0];
            if (requestParts.Length > 1)
            {
                string body = requestParts[1];
                this.Body = body;
            }

            string[] headerParts = headLineAndHeaders.Split("\r\n", 2);
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

            string[] headLineParts = headLine.Split(" ");

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
            string[] allHeaders = headers.Split("\r\n");

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



        // 1. ----> HeadLine <---- Method || Path || Http_Version
        //GET /trainings/3164/csharp-web-basics-september-2020/internal HTTP/1.1 

        //2. List<Header>
        //3. add class header with Name and Value properties
        //Host: softuni.bg
        //Connection: keep-alive
        //Pragma: no-cache
        //Cache-Control: no-cache
        //Upgrade-Insecure-Requests: 1
        //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36
        //Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
        //Sec-Fetch-Site: same-origin
        //Sec-Fetch-Mode: navigate
        //Sec-Fetch-User: ?1
        //Sec-Fetch-Dest: document
        //Referer: https://softuni.bg/trainings/3164/csharp-web-basics-september-2020/internal
        //Accept-Encoding: gzip, deflate, br
        //Accept-Language: bg-BG,bg;q=0.9,en;q=0.8
        //Cookie: _ga=GA1.2.771947856.1559822829; fbp=fb.1.1591281385933.1246513774; .auth.softuni=QfwKkoffYStU2baq9cfiz2jhLBH-b76yBE7r1ePpDj-G-9dVuy4ZJEKYzthlN2iYB5BtZK_E_f4fMqAFFg07S6QGalqi-IEwnpkfNzEvDddFkT3u9ZQpugYNW3qnYWE0QQMZMcbLO7CYqRh_E_iTTyD7w2NKBZq-CGjIYNKNWeOEeP7Z1nfbJkemV0f2ijsftzHrLoeqOvXghOV9r2vqH4euhVq7hvjO6qRLH9CzwOJ4YQS_FQCP39ucYBXiEQn84Iaf3y2RySCMC66LAJOO6hYZF2Pu17iiD2AjMHqPBJ_Bn7h5RYN4FJDj1tUM1bS-Mpo1e2fa7sAW-jQBxXozSmFpHq1D6OpismJlaJ2yyp_HFpxjOJvmH4WQDTNGok3izMTBAdibuvlT6nPajSRPeyFbwl4lMMivtWhoYGvnLUaDzJaJMNGc_S3yR38Euv-gCryYDbUufAscb-sGtwfQ7eJ7Ok3ouD5ujV0BQBsm81I3054o7X3AUhngOqmArjXGCD_wSRt_8qUYEYhYr42BYjXbwBvsBvG5WF_FnKV672eLV6jzF7EGLVpUPBhea9VrcY23ohGy7SPT2yjfMin4wzlga43hM4t_Bf3doQGz2Ht27YUu-GJbERmviTXj_LRmfdk1tp5plmcf_ZWolCyumyR_dlF3oydUeH63zeWLX2IozvpX3rH9nGqSPhA9SpnUK-T7xCXS2gUXDzXIob-RM3aorRETqUxzs6P-UhbweeoNxfUxSofrcti4z77NOICUY-rD10eh_6BcpJVUfAyBLmW7WIo-dP1gRW0o6xlXSPbIULlgEfP52AvNIYP9Amm0WFmW4onAGxz4ZKwSa_R4ffK4DkRXxf1uelwbSUlnUCZyRKqo4B4Jdu2Yjna2tt9NEZI1hqW6_JW1ordjWLEoyhpijPbZ5-Redof00fEmjLEdqbsvihYuzuVx1J6LlZ9_eKTNxMdzIwDzAY-Z-MBJSNq31Dqc8b6meNb59ZuEBn_FeAx1fmujjyGbARNUk4pA5urqy6qd8KH2oONjLos1p0bbASVVFWPBK3yLSJSPPZZeas01CEUzKFlkkp_qOkbdQoksmNedRWkWN3tbI-e1q4E27ATqEn9l_QUy1jVy6OVgHRcwgcCGI5MWydLeYc4lrIL6nvzRRI9gyOecpCb2Xx058-KiZ_Kw1Bhu7phKyoaQwyd9eMsYX90OAq50nCNdhsI2mYp4ETPr8AO8aLldF-gtdFUj4EmlJII4SaV7wbAtst1W3AB6Ug7qKYeW6WA3maz1ViAG_3D0gtNgnUskNW8_CRpmiWKKPaEOa1QYO5WM4muaP9Fa0qkOL1qmVtEaxiVkOlMg7FXn8V6glkNMDQUn74HY-NGDFonG77KBtar3kHO5FtUjK6OozPAXei4P3H_72yBHqBcVsG5O35_Sl2rj2bi_CG6SVXZkzZiAwb18NeSIPXcTcrc2nWobjJ2SFi--aW9HopSFBxo9fmvSj90ZIDhFNY_u1nYrmvpguqIlq3ioAur_L8aX0ASAjnzou_nz87zBuApFDLJwsKd3acBW2VMb-gvQe_IJPf5wJm1iWMwYonFagLGQKtPR7Gw_eClS1v036_hFgH4B5CJosnKZVRSwxrj7vcYKjqsMPo8UOSuGKYbNgglOMulMrg6Y9S32oUHX19Sr0N--iAoJUOtazudH0UK21zL83WlibVTeZnmgzbZR_hf9fyzh8Gw0Ave5sNYAL9_C9F7G117MJsXRaml0D2EpxL9gpecc8eqMic-XJttU_LbpHfH2_WIjNUNsaXakqtZ8CcKN4tRLBO_FL_THcmRRK0HtkuWvYvEXLfyWnb5VnIi1bOOY70RgDlcKREUbxGBRDCDp3ZCoey1F4NtHlz9gQSZWXaikbVTmvddqQhYKumxJUTZMuxuZKYfkZ88pBnAAKfHvxnHOKpnWi0onMPFYjJStfpUF2acC1eyENIQiYNJFirDhLJAWo-_TF-zpOzztQdUx7EQHtig5IBdyIkq6IXgApNkXHZ-SSyfAD78lMeyCxXUGtf9bH5FmoPQlfHSZlgicvM9FcZhh93D3Orn83Uda2EMgw5GkSE40NZFgSaHi0SNbME7nCnR_4zGTQ9SF4CXaIUz01ON44wwVcdufitWivhIqCfAYQRAzUAY7OCeAErqRz50-e6mlnNot

        //idsrv.xsrf=rsvn8yb76JY47NXiWGfGsZ-A7vrxkixVx7o2qqRpf4nfx61hhOmrhemelBMvfI0NjJIs-oo-S0EmCxIgrT-_Fz_3qpQ&username=joro_paspalev&password=Viki8301&RememberMe=true&RememberMe=false




    }
}
