using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTS.Services;
using QTS.Commons;

namespace QTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseAPIController
    {
        private UnitOfWorks unitOfWork;
        public TestController()
        {
            unitOfWork = GetUnitOfWork();
        }
        [HttpGet]   
        public HttpResult Get()
        {
            var result = unitOfWork.TestRepository.Test();
            return new HttpResult(MessageCode.Success,"Thanh Cong",result);
        }
    }
}
