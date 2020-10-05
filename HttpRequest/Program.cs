using System;

namespace HttpRequest
{
    class Program
    {
        static void Main(string[] args)
        {

            var dog = new Dog("Ivan", 12) { Owner = "Bai Marin", Town = "Ruse" };
            ;





            string text = @"GET /users/profile/show/joro_paspalev HTTP/1.1
Host: softuni.bg
Connection: keep - alive
Pragma: no - cache
Cache - Control: no - cache
Upgrade - Insecure - Requests: 1
User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 85.0.4183.121 Safari / 537.36
Accept: text / html,application / xhtml + xml,application / xml; q = 0.9,image / avif,image / webp,image / apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
Sec-Fetch-Site: same-origin
Sec-Fetch-Mode: navigate
Sec-Fetch-User: ?1
Sec-Fetch-Dest: document
Referer: https://softuni.bg/
Accept-Encoding: gzip, deflate, br
Accept-Language: bg-BG,bg;q=0.9,en;q=0.8
Cookie: _ga=GA1.2.771947856.1559822829; _fbp=fb.1.1591281385933.1246513774; _fbc=fb.1.1601448518200.IwAR1-CctqFYWPirnu6CA_PIDeDWSaiqOX6rPtNljA88G402x9VpKMIIfW_ks; _gid=GA1.2.828654170.1601543818; ASP.NET_SessionId=vkvyfxxyssabhitbyeuuw1ab; language=bg; __RequestVerificationToken=mo7H7_pLazstLfWoytbYR8HqiqFl7w6992AKOgijQpP_9Y5yjd3SOKd4IPSzQnQEDtOm1SJdMflPioAkaMLoy5a2H081; OpenIdConnect.nonce.byjJo0%2FIpoqzmw8G%2F0xmkYM4fAZeHIlSczCsEvk3pCk%3D=ejNFTzNoM3YtT0NVMW9IakgydDgzYmtsbHgwZXczaGJOdUl2TEozMzRZVXlvYkh3bGhHdnE2V2tFZkl0UVlvTV9iX0FoT0MwaVBpTkNlMmU5em9OeXQtZjN1ZVMzZkRSQ0pEWVNZVW81ZXl0VVZuQmFfTGdXNXdkaUU0UFAybnVkSGQ1Zk1FSTRkVWFvdjF4RlVDX2ViOUdPdGxQVmp5ZG9DZlNwem5CMGlVQ0lVeGlNS1g3aFBqRGxIRXhfWDV5cmoyYklobHFoYVdEbWYxcGRyU1lENGl3cW1R";

            HttpRequest request = new HttpRequest(text);

            Console.WriteLine(request);
        }
    }
}
