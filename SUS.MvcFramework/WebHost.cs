using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    //Този WebHost ми трябва за да изнеса в него логиката по стартирането на server-a
    public static class WebHost
    {
        public static async Task RunAsync(List<Route> routesTable, int port = 80)
        {
            //Искам да мога да си създам инстанция на сървъра
            var server = new HttpServer(routesTable);
           
            //Искам да мога да стартирам по някакъв начин сървъра
            await server.StartAsync(port);
        }
    }
}
