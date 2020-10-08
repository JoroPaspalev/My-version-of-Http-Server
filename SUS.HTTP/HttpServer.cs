using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        List<Route> routeTable = new List<Route>();

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        public async Task StartAsync(int port = 80)
        {
            //Тук слушам за заявки от браузъра
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();

            while (true)
            {
                // Тук казвам Случашо, чакай да дойде някакъв Request от браузъра и ми го дай
                TcpClient client = await listener.AcceptTcpClientAsync();
                // искам след като е дошла заявка от клиента да я парсна и създам отделни обекти за да мога ги ползвам наготово после, когато ми потрябват, а не да ги парсвам постоянно.
                ProcessClient(client);
            }
        }

        private async Task ProcessClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[500];
                int position = 0;
                List<byte> inputBytesFromStream = new List<byte>();

                while (true)
                {
                    int count = await stream.ReadAsync(buffer, position, buffer.Length);

                    if (count < buffer.Length)
                    {
                        byte[] leftBytes = new byte[count];
                        Array.Copy(buffer, leftBytes, count);
                        inputBytesFromStream.AddRange(leftBytes);
                        break;
                    }
                    else
                    {
                        inputBytesFromStream.AddRange(buffer);
                    }
                }

                string requestAsString = Encoding.UTF8.GetString(inputBytesFromStream.ToArray());

                //До тук получихме от Stream-а Chunks of data записахме ги в един List и от листа направихме string. Сега искаме този string да го обърнем на обект HttpRequest

                HttpRequest request = new HttpRequest(requestAsString);


                // Искам да създам нов Response така: 
                // new HttpResponse(string contentType, StatusCode statusCode = 200, byte[] body ). Казва така: Аз ще ти направя Response, но ти ми дай в конструктора статус кода защото аз не го знам, дай ми прочетения Html като байт масив, дай ми и статус кода като стринг и аз ще ти върна Request

               
                HttpResponse response;

                Route currRoute = routeTable.FirstOrDefault(r => r.Path == request.Path);

                if (currRoute != null)
                {
                    var action = currRoute.Action;
                    response = action(request);
                }
                else
                {
                    byte[] fileNotFound = File.ReadAllBytes(@"views/home/notFound.html");
                    response = new HttpResponse("text/html", fileNotFound, HttpStatusCode.NotFound);
                }

                byte[] reasponseAsByte = Encoding.UTF8.GetBytes(response.ToString());
                await stream.WriteAsync(reasponseAsByte, 0, reasponseAsByte.Length);
                await stream.WriteAsync(response.Body, 0, response.Body.Length);
            }

            client.Close();
        }
    }
}
