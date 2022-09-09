using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using QTS.Commons;
using QTS.Services;
namespace QTS.API
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthenticationToken : Attribute, IAuthorizationFilter
    {
        private UnitOfWorks unitOfWorks;
        public AuthenticationToken()
        {
            unitOfWorks = UnitOfWorkFactory.GetUnitOfWork();
        }
        /// <summary>
        /// Validate access token
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {              
                var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();                
                bool temp = false;
                // check token is valid here
                if (temp)
                {
                    return;
                }
                else
                {
                    context.HttpContext.Response.Headers.Add("AuthStatus", "UnAuthorized");
                    context.HttpContext.Response.StatusCode = Functions.ParseInt(HttpStatusCode.Forbidden);
                    context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "UnAuthorized";
                    context.Result = new JsonResult("UnAuthorized")
                    {
                        Value = new
                        {
                            MessageCode = MessageCode.Unauthorized,
                            message = "Unauthorized",
                            content = "Unauthorized"
                        },
                    };
                }                          
            }
            catch (Exception ex)
            {
                context.Result = new JsonResult("UnAuthorized")
                {
                    Value = new
                    {
                        MessageCode = MessageCode.Error,
                        message = Functions.ToString(ex.Message),
                        content = Functions.ToString(ex.Message)
                    },
                };
            }
        }
    }
}
