using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Logic.Extention
{
   public static class EmailTemplateAndDataMapper
    {
        public static string GetHandleBarTemplate<T>(this T obj, string sourcePath) where T : new()
        {

            string templatePath = System.Web.Hosting.HostingEnvironment.MapPath(sourcePath);
            string source = File.ReadAllText(templatePath);

            Func<object, string> template = Handlebars.Compile(source);
            string result = template(obj);

            return result;
        }
    }
}
