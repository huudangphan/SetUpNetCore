using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QTS.Commons;
using QTS.Entity;
using QTS.Services.Interfaces;

namespace QTS.Services.Repositories
{
    public class AuthRepository : GenericRepository<UserEntity>, IAuth
    {            
        public AuthRepository(AppDbContext context) : base(context)
        {
        }
        public string GenerateToken(UserEntity user)
        {
            var issuer = GlobalData.issuer;
            var audience = GlobalData.audience;
            var key = Encoding.UTF32.GetBytes(GlobalData.key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                            new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                         }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);   
            var stringToken = tokenHandler.WriteToken(token);        
            return stringToken;
        }
    }    
}
