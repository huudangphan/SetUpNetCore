using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QTS.Commons;
using QTS.Entity;
using QTS.Services.Interfaces;
using static QTS.Commons.Enums;
namespace QTS.Services.Repositories
{
    public class TestRepository:GenericRepository<TestEntity>,Itest
    {
        public AppDbContext context;
        public TestRepository(AppDbContext context) :base(context)
        {
            this.context = context;
        }
        private IEnumerable<TestEntity> list { get; set; }

        public HttpResult Add(TestEntity id)
        {
            return Process(id, ActionType.Add);
        }

        public HttpResult Delete(TestEntity id)
        {
            return Process(null, ActionType.Remove);
        }

        public HttpResult Update(TestEntity id)
        {
            return Process(null, ActionType.Update);
        }

        /// <summary>
        ///  function to ensure all functions use the same transaction
        /// </summary>
        /// <param name="ds">parameter pass to api</param>
        /// <param name="type">type query </param>
        /// <returns></returns>
        protected override HttpResult Process(TestEntity ds, Enums.ActionType type)
        {
            using (var tran = database.BeginTransaction())
            {
                var result = ProcessData(ds, type);
                context.SaveChanges();
                tran.Commit();
                return result;
            }                    
        }
        protected override HttpResult ProcessData(TestEntity ds, Enums.ActionType type)
        {
            switch (type)
            {
                case ActionType.Select:
                    // write code select data here
                    list = context.TestEntity.ToList();
                    return new HttpResult(
                        MessageCode.Success,
                       "Thanh cong",
                       list
                        );                    
                    break;
                case ActionType.Add:
                    // write code add here                    
                    int id = ds.Id;
                    context.TestEntity.Add(new TestEntity { Id=id});
                    return new HttpResult(MessageCode.Success);                        
                    break;
                case ActionType.Remove:
                    // write remove add here
                    break;
                case ActionType.Update:
                    // write update add here
                    break;
            }
            return new HttpResult();
        }
        /// <summary>
        /// Function is called from controller.
        /// Every function like it is call to function "Process"
        /// </summary>
        /// <param name="type">type query data </param>
        /// <returns></returns>
        HttpResult Itest.Select(ActionType type)
        {
            return Process(null, ActionType.Select);
        }
    }
}
