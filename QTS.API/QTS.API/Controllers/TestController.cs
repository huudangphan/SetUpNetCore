using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTS.Services;
using QTS.Commons;
using QTS.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace QTS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : BaseAPIController
    {
        private UnitOfWorks unitOfWork;    
       
        public TestController()
        {        
            unitOfWork=GetUnitOfWork();
        }              
       
        [HttpGet]   
        public HttpResult Get()
        {            
            var result = unitOfWork.TestRepository.Test();
            return result;
        }
    }
}
