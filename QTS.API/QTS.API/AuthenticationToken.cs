using Microsoft.AspNetCore.Mvc.Filters;

namespace QTS.API
{
    public class AuthenticationToken : ActionFilterAttribute
    {
        public AuthenticationToken()
        {
        }
    }
}
