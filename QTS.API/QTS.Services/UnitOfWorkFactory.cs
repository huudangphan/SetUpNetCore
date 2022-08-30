using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTS.Services
{
    public static class UnitOfWorkFactory
    {     
        public static UnitOfWorks GetUnitOfWork()
        {
            return new UnitOfWorks();
        }
    }
}
