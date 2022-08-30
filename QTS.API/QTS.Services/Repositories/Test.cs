using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Commons;
using QTS.Entity;
using QTS.Services.Interfaces;
using static QTS.Commons.Enums;
namespace QTS.Services.Repositories
{
    public class Test:GenericRepository<TestEntity>,Itest
    {
        public AppDbContext context;
        public Test(AppDbContext context) :base(context)
        {
            this.context = context;
        }
        private IEnumerable<TestEntity> list { get; set; }
        protected override HttpResult Process(DataSet ds, Enums.ActionType type)
        {
            var result = ProcessData(ds, ActionType.Select);
            return result;
        }
        protected override HttpResult ProcessData(DataSet ds, Enums.ActionType type)
        {
            switch (type)
            {
                case ActionType.Select:
                    list = context.TestEntity.ToList();
                    return new HttpResult(
                        MessageCode.Success,
                       "Thanh cong",
                       list

                        );                    
                    break;
                case ActionType.Add:
                    break;
            }
            return new HttpResult();
        }

        HttpResult Itest.Test(ActionType type)
        {
            return Process(null, ActionType.Select);
        }
    }
}
