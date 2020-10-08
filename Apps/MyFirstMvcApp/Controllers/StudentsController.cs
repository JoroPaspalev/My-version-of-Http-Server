using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class StudentsController : Controller
    {
        public HttpResponse StudentGrades(HttpRequest request)
        {
            return this.View();
        }
    }
}
