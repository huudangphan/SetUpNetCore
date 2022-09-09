using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTS.Services;
using QTS.Commons;
using QTS.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static QTS.Commons.Enums;
using System.Data;
using QTS.Entity;
namespace QTS.API.Controllers
{
    //[AuthenticationToken] 
    
    public class TestController : BaseAPIController
    {
        private UnitOfWorks unitOfWork;
        public IConfiguration Configuration { get; }
        public TestController()
        {        
            unitOfWork=GetUnitOfWork();
        }              
       
        [HttpGet]   
        public HttpResult Get()
        {            
            var result = unitOfWork.TestRepository.Select(ActionType.Select);
            return result;
        }
        [HttpPost]
        public HttpResult Add([FromBody] TestEntity ds)
        {
            /// Test generate access token
            string accessToken=unitOfWork.AuthRepository.GenerateToken(new UserEntity { userName = "user", passWord = "pass" });
            ///////
            var result = unitOfWork.TestRepository.Add(ds);
            return result.Result;
        }
    }
}
