using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class ProductsController : Controller
    {
        public HttpResponse Adidas(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Nike(HttpRequest request)
        {
            return this.View();                 
        }

        public HttpResponse PumaNewArrival(HttpRequest request)
        {
            return this.View();            
        }
    }
}
