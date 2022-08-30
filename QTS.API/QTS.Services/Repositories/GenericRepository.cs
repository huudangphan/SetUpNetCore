using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Entity;
using QTS.Commons;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static QTS.Commons.Enums;

namespace QTS.Services.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        internal AppDbContext Context;
        public DatabaseClient database { get; set; }
        public GenericRepository(AppDbContext context)
        {
            this.Context = context;
           

        }
        protected virtual HttpResult Process(DataSet ds,ActionType type)
        {
            try
            {
                using (var tran = database.BeginTransaction())
                {

                    var result = ProcessData(ds,type);
                    tran.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new HttpResult(MessageCode.Error, Functions.ToString(ex));
                
            }
           
        }
        protected abstract HttpResult ProcessData(DataSet ds,ActionType type);
        
        public IQueryable<TEntity> Select()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Single(predicate);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().First(predicate);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("object is null");

            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("object is null");

            Context.Set<TEntity>().Remove(entity);
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("object is null");

            Context.Set<TEntity>().Attach(entity);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
