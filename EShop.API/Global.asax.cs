#region Using

using Newtonsoft.Json.Converters;
using System.Web;
using System.Web.Http;

#endregion

namespace EShop.API
{
    public class Application : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            //LogConfiguration.SetLogger("cp.txt", "%date %level %logger - %message%newline");
        }
    }
}