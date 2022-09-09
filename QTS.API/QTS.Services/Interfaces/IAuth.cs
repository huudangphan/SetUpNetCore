using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Entity;
namespace QTS.Services.Interfaces
{
    public interface IAuth
    {
        string GenerateToken(UserEntity user);
    }
}
