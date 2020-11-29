using EShop.Entity;
using System;
using System.Net.Http;
using System.Web.Http.Filters;

namespace EShop.API.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Exception)
            {
                var baseResponse = new BaseResponse() { IsError = true, IsNull = true };
                baseResponse.Message = "System error has occurred. Please contact system administrator.";
                baseResponse.DeveloperLog = context.Exception.Message;
                context.Response = context.Request.CreateResponse(System.Net.HttpStatusCode.OK, baseResponse);

            }
        }
    }
}