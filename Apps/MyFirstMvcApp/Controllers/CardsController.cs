using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse All(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Add(HttpRequest response) => this.View();       

        public HttpResponse Collection(HttpRequest response) => this.View();
       
    }
}
