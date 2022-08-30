using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Commons;
using static QTS.Commons.Enums;
namespace QTS.Services.Interfaces
{
    public interface Itest
    {
        public HttpResult Test(ActionType type);
    }
}
