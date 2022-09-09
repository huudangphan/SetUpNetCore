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

        async Task<HttpResult> Itest.Add(TestEntity id)
        {
            try
            {
                int _id = id.Id;
                await context.TestEntity.AddAsync(new TestEntity { Id = _id });
                await context.SaveChangesAsync();
                return new HttpResult(MessageCode.Success);
            }
            catch (Exception ex)
            {

                return new HttpResult(MessageCode.Error, Functions.ToString(ex.Message));
            }            
        }
        public async Task<HttpResult> Delete(TestEntity id)
        {
            try
            {
                var obDelete = await context.TestEntity.FindAsync(id);
                if (obDelete != null)
                {
                    context.TestEntity.Remove(obDelete);
                    await context.SaveChangesAsync();
                }

                return new HttpResult(MessageCode.Success);
            }
            catch (Exception ex)
            {
                return new HttpResult(MessageCode.Error, Functions.ToString(ex.Message));
            }            
        }

        public async Task<HttpResult> Update(TestEntity id)
        {
            return new HttpResult(MessageCode.Success);
        }               
       
        HttpResult Itest.Select(ActionType type)
        {
            try
            {
                list = context.TestEntity.ToList();
                return new HttpResult(
                    MessageCode.Success,
                   "Success",
                   list
                    );
            }
            catch (Exception ex)
            {
                return new HttpResult(MessageCode.Error, Functions.ToString(ex.Message));
            }
           
         
        }
    }
}
