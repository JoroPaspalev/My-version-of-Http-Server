using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class ProductController : Controller
    {
        public HttpResponse ProductsAdidas(HttpRequest arg)
        {
            byte[] adidasProductsAsByte = File.ReadAllBytes(@"wwwroot/productsAdidas.html");
            return new HttpResponse("text/html", adidasProductsAsByte, HttpStatusCode.Ok);
        }

        public HttpResponse ProductsNike(HttpRequest request)
        {
            var productAsByte = File.ReadAllBytes(@"wwwroot/productsNike.html");
            var response = new HttpResponse("text/html", productAsByte, HttpStatusCode.Ok);
            return response;
        }
        public HttpResponse ProductsPumaNewArrival(HttpRequest arg)
        {
            byte[] pumaNewarrivalAsByte = File.ReadAllBytes(@"wwwroot/puma.html");
            return new HttpResponse("text/html", pumaNewarrivalAsByte, HttpStatusCode.Ok);
        }
    }
}
