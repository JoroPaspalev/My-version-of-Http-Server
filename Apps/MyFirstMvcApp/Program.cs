using System.Threading.Tasks;
using SUS.HTTP;
using MyFirstMvcApp.Controllers;
using SUS.MvcFramework;
using System.Collections.Generic;
using System;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {           
            List<Route> routesTable = new List<Route>();

            // Искам да мога да добявям път, който като се въведе в браузъра да извиква определен метод който да се изпълни и да ми връща определено View
            //Това са ти route-овете
            routesTable.Add(new Route("/", new HomeController().Index));
            routesTable.Add(new Route("/about", new HomeController().About));
            routesTable.Add(new Route("/contacts", new HomeController().Contacts));
            routesTable.Add(new Route("/users/login", new UsersController().Login));
            routesTable.Add(new Route("/users/register", new UsersController().Register));
            routesTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routesTable.Add(new Route("/products/nike", new ProductsController().Nike));
            routesTable.Add(new Route("/products/nike.jpg", new StaticFilesController().Nike));
            routesTable.Add(new Route("/products/air-max-270.jpg", new StaticFilesController().NikeAirMax));
            routesTable.Add(new Route("/products/adidas", new ProductsController().Adidas));
            routesTable.Add(new Route("/products/adidas-flat-run.jpg", new StaticFilesController().ProductsAdidasFlatRun));
            routesTable.Add(new Route("/products/adidas-green.jpg", new StaticFilesController().ProductsAdidasGreen));
            routesTable.Add(new Route("/products/puma", new ProductsController().PumaNewArrival));
            routesTable.Add(new Route("/products/puma-enzo-2.jpg", new StaticFilesController().ProductsPumaNewArrivalEnzo2));
            routesTable.Add(new Route("/products/puma-bmw.jpg", new StaticFilesController().ProductsPumaNewArrivalBmw));
            routesTable.Add(new Route("/students", new StudentsController().StudentGrades));
            routesTable.Add(new Route("/cards/all", new CardsController().All));
            routesTable.Add(new Route("/cards/add", new CardsController().Add));
            routesTable.Add(new Route("/cards/collection", new CardsController().Collection));
            routesTable.Add(new Route("/shared/error", new SharedController().Error));
            routesTable.Add(new Route("/shared/layout", new SharedController()._Layout));

            //Това казва пусни Application да работи на порт еди кой си, който App да работи на подадените му пътища в routeTable със съответната функционалност.
            await WebHost.RunAsync(routesTable, 80);

        }
    }
}
