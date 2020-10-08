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
            var response = this.View();
            response.Headers.Add(new Header("Server-Name", "Joro's Server"));
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) { HttpOnly = true, MaxAge = 12000, Path = "/" });
            return response;
        }
       
        public HttpResponse Contacts(HttpRequest request)
        {            
            var response = this.View();
            response.Cookies.Add(new ResponseCookie("theme", "dark")
            { Path = "/contacts" });
            return response;
        }

        public HttpResponse About(HttpRequest request)
        {
            var response = this.View();
            response.Cookies.Add(new ResponseCookie("id", "Very-Importatnt-Cookie")
            { HttpOnly = true, MaxAge = 12000, Path = "/" });
            response.Cookies.Add(new ResponseCookie("thisCookieIsOnlyVisibleForAboutPage", "Not_important_cookie")
            { Path = "/about" });
            return response;
        }        
    }
}
