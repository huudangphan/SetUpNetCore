using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Commons;
using static QTS.Commons.Enums;
using QTS.Entity;
namespace QTS.Services.Interfaces
{
    public interface Itest
    {
        public HttpResult Select(ActionType type);
        public Task<HttpResult> Delete(TestEntity id);
        public Task<HttpResult> Add(TestEntity id);
        public Task<HttpResult> Update(TestEntity id);
    }
}
