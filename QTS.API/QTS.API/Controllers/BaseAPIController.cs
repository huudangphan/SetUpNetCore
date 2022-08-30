using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTS.Services;

namespace QTS.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        protected UnitOfWorks unitOfWorks;
        public BaseAPIController()
        {
            
        }
        protected UnitOfWorks GetUnitOfWork()
        {
            return UnitOfWorkFactory.GetUnitOfWork();
        }
       
    }
}
