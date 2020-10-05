using SUS.HTTP;
using System;
using System.IO;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            byte[] readedFile = File.ReadAllBytes(@"wwwroot/index.html");

            var response = new HttpResponse("text/html; charset=utf-8", readedFile, HttpStatusCode.Ok);
            response.Headers.Add(new Header("Server-Name", "Joro's Server"));
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) { HttpOnly = true, MaxAge = 12000, Path = "/" });

            return response;
        }
       
        public  HttpResponse Login(HttpRequest request)
        {
            byte[] readedFile = File.ReadAllBytes(@"wwwroot/login.html");

            var response = new HttpResponse("text/html; charset=utf-8", readedFile, HttpStatusCode.Ok);
            response.Headers.Add(new Header("Server-Name", "Joro's Server"));
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 12000, Path = "/" });

            return response;
        }

        public HttpResponse Contacts(HttpRequest request)
        {
            byte[] body = File.ReadAllBytes(@"wwwroot/contactForm.html");

            var response = new HttpResponse("text/html", body, HttpStatusCode.Ok);
            response.Cookies.Add(new ResponseCookie("theme", "dark")
            { Path = "/contacts" });

            return response;
        }

        public HttpResponse About(HttpRequest request)
        {
            byte[] aboutHtml = File.ReadAllBytes(@"wwwroot/about.html");

            var response = new HttpResponse("text/html", aboutHtml, HttpStatusCode.Ok);
            response.Cookies.Add(new ResponseCookie("id", "Very-Importatnt-Cookie")
            { HttpOnly = true, MaxAge = 12000, Path = "/" });
            response.Cookies.Add(new ResponseCookie("thisCookieIsOnlyVisibleForAboutPage", "Not_important_cookie")
            { Path = "/about" });

            return response;
        }

        
    }
}
