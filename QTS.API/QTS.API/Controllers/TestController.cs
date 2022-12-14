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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace QTS.API.Controllers
{
    //[AuthenticationToken] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var result = unitOfWork.TestRepository.Select(ActionType.Select);
            return result;
        }
        [HttpPost]
        public HttpResult Add([FromBody] TestEntity ds)
        {            
            var result = unitOfWork.TestRepository.Add(ds);
            return result.Result;
        }
    }
}
