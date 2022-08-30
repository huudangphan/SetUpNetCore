using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Commons;
using QTS.Entity;
using QTS.Services.Interfaces;
namespace QTS.Services.Repositories
{
    public class Test : Itest
    {
        public AppDbContext context;
        public Test(AppDbContext context) 
        {
            this.context = context;
        }
        private IEnumerable<TestEntity> list { get; set; }
        HttpResult Itest.Test()
        {
            list = context.TestEntities.ToList();           
            return new HttpResult(
                MessageCode.Success,
               "Thanh cong",
               list

                );
        }
    }
}
