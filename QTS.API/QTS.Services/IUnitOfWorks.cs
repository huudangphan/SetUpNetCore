using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Services.Interfaces;
namespace QTS.Services
{
    public interface IUnitOfWorks :IDisposable
    {
        Itest TestRepository { get; }
    
    }
}
