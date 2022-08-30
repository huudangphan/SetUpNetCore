using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTS.Services.Interfaces
{
    public interface IDatabaseClient
    {
        DbTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);
    }
}
