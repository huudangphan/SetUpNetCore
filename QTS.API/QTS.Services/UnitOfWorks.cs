using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Services.Interfaces;
using QTS.Services.Repositories;
using QTS.Entity;
using System.Data.Entity;


namespace QTS.Services
{
    public class UnitOfWorks
    {
        private GenericRepository<TestEntity> testRepository;
        private readonly AppDbContext context;
        public UnitOfWorks(AppDbContext context)
        {
            this.context = context;
        }

        public Itest TestRepository
        {
            get { return new Test(context); }
        }        
       
    }
}
