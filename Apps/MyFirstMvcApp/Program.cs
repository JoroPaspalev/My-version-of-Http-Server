using System.Threading.Tasks;
using SUS.HTTP;
using MyFirstMvcApp.Controllers;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Искам да мога да си създам инстанция на сървъра
            var server = new HttpServer();

            // Искам да мога да добявям път, който като се въведе в браузъра да извиква определен метод който да се изпълни и да ми връща определено View
            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/contacts", new HomeController().Contacts);
            server.AddRoute("/login", new HomeController().Login);
            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);
            server.AddRoute("/products/nike", new ProductController().ProductsNike);
            server.AddRoute("/products/nike.jpg", new StaticFilesController().Nike);
            server.AddRoute("/products/air-max-270.jpg", new StaticFilesController().NikeAirMax);
            server.AddRoute("/products/adidas", new ProductController().ProductsAdidas);
            server.AddRoute("/products/adidas-flat-run.jpg", new StaticFilesController().ProductsAdidasFlatRun);
            server.AddRoute("/products/adidas-green.jpg", new StaticFilesController().ProductsAdidasGreen);
            server.AddRoute("/products/new/puma", new ProductController().ProductsPumaNewArrival);
            server.AddRoute("/products/new/puma-enzo-2.jpg", new StaticFilesController().ProductsPumaNewArrivalEnzo2);
            server.AddRoute("/products/new/puma-bmw.jpg", new StaticFilesController().ProductsPumaNewArrivalBmw);

            //Искам да мога да стартирам по някакъв начин сървъра
            await server.Start();
        }


       
    }
}
