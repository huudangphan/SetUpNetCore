using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTS.Services;
using QTS.Commons;
using QTS.Entity;
namespace QTS.API.Controllers
{
  
    [ApiController]
    public class UserController : BaseAPIController
    {
        private UnitOfWorks unitOfWork;
        public UserController()
        {
            unitOfWork = GetUnitOfWork();
        }
        [HttpPost]
        public HttpResult Login([FromBody]UserEntity user )
        {
            var token = unitOfWork.AuthRepository.GenerateToken(user);
            return new HttpResult(MessageCode.Success,"Login success",token); 
        }
    }
}
