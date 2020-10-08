using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            var response = this.View();
            response.Headers.Add(new Header("Server-Name", "Joro's Server"));
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 12000, Path = "/" });

            return response;
        }
        public HttpResponse Register(HttpRequest request)
        {
            HttpResponse response = this.View();
            response.Headers.Add(new Header("Server-Name", "Joro's Server"));
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 12000, Path = "/" });

            return response;
        }

    }
}
