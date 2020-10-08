using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        //[CallerMemberName] - този атрибут извиква името на метода от който идваме и го записва в string viewPath. Примерно идваме от HomeController/Index action-a ще вземе името на action-a което е "Index" като string
       public HttpResponse View([CallerMemberName]string viewPath = null)
        {
            //Искам да взема типа на текущата инстанция, която влиза в Base class Controller т.е. ще е някоя от наследниците --> CardsController, UsersControllers....Това става чрез this.GetType().Name --> Това ще ми върне примерно CardsController, след това махам Controller и го замествам с /
            string controllerName = this.GetType().Name.Replace("Controller", "/"); //Cards/      

            //зареждането на Layout-a винаги става от папка Shared, затова можем да направим така:
            //string layout = System.IO.File.ReadAllText("views/shared/_Layout.html");
            //string partialView = System.IO.File.ReadAllText("views/" + controllerName + viewPath + ".html");
            //string readyHtml = layout.Replace("@RenderBody()", partialView);


            //byte[] readyHtmlAsByteArray = Encoding.UTF8.GetBytes(readyHtml);

            byte[] readyHtmlAsByteArray = System.IO.File.ReadAllBytes("views/" + controllerName + viewPath + ".html");
            return new HttpResponse("text/html; charset=utf-8", readyHtmlAsByteArray, HttpStatusCode.Ok);
        }

        public HttpResponse File(string path, string contentType)
        {
            byte[] fileAsByte = System.IO.File.ReadAllBytes("wwwroot/" + path);
            return new HttpResponse(contentType, fileAsByte, HttpStatusCode.Ok);
        }

    }
}
