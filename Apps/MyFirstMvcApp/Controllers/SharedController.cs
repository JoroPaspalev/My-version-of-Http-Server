using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class SharedController : Controller
    {
        public HttpResponse Error(HttpRequest request)
        {
            return this.View();            
        }

        public HttpResponse _Layout(HttpRequest request)
        {
            return this.View();
        }
    }
}
