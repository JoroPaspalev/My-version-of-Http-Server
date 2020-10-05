using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            byte[] iconAsByte = File.ReadAllBytes(@"wwwroot/funny-1710408-1451693.png");
            return new HttpResponse("image/x-icon", iconAsByte, HttpStatusCode.Ok);            
        }

        public HttpResponse NikeAirMax(HttpRequest arg)
        {
            byte[] airAsByte = File.ReadAllBytes(@"wwwroot/air-max-270.jpg");
            return new HttpResponse("image/jpg", airAsByte, HttpStatusCode.Ok);
        }

        public HttpResponse Nike(HttpRequest request)
        {
            var nikeAsByte = File.ReadAllBytes(@"wwwroot/nike.jpg");
            return new HttpResponse("image/jpeg", nikeAsByte, HttpStatusCode.Ok);
        }

        public HttpResponse ProductsPumaNewArrivalEnzo2(HttpRequest arg)
        {
            byte[] enzo2AsByte = File.ReadAllBytes(@"wwwroot/puma-enzo-2.jpg");
            return new HttpResponse("image.jpeg", enzo2AsByte, HttpStatusCode.Ok);
        }

        public HttpResponse ProductsPumaNewArrivalBmw(HttpRequest arg)
        {
            byte[] bmwAsByte = File.ReadAllBytes(@"wwwroot/puma-bmw.jpg");
            return new HttpResponse("image/jpeg", bmwAsByte, HttpStatusCode.Ok);
        }
        
        public HttpResponse ProductsAdidasGreen(HttpRequest arg)
        {
            byte[] adidasGreenAsByte = File.ReadAllBytes(@"wwwroot/adidas-green.jpg");
            return new HttpResponse("image/jpeg", adidasGreenAsByte, HttpStatusCode.Ok);
        }

        public HttpResponse ProductsAdidasFlatRun(HttpRequest arg)
        {
            byte[] adidasFlatAsByte = File.ReadAllBytes(@"wwwroot/adidas-flat-run.jpg");
            return new HttpResponse("image/jpeg", adidasFlatAsByte, HttpStatusCode.Ok);
        }
    }
}
