using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.File("funny-1710408-1451693.png", "image/x-icon");                    
        }

        public HttpResponse NikeAirMax(HttpRequest arg)
        {
            return this.File("air-max-270.jpg", "image/jpg");
        }

        public HttpResponse Nike(HttpRequest request)
        {
            return this.File("nike.jpg", "image/jpeg");
        }

        public HttpResponse ProductsPumaNewArrivalEnzo2(HttpRequest arg)
        {
            return this.File("old/puma-enzo-2.jpg", "image.jpeg");
        }

        public HttpResponse ProductsPumaNewArrivalBmw(HttpRequest arg)
        {
            return this.File("puma-bmw.jpg", "image.jpeg");
        }
        
        public HttpResponse ProductsAdidasGreen(HttpRequest arg)
        {
            return this.File("adidas-green.jpg", "image.jpeg");
        }

        public HttpResponse ProductsAdidasFlatRun(HttpRequest arg)
        {
            return this.File("adidas-flat-run.jpg", "image.jpeg");
        }
    }
}
