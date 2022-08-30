using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Services.Interfaces;
using QTS.Services.Repositories;
using QTS.Entity;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using QTS.Commons;
namespace QTS.Services
{
    public class UnitOfWorks:IUnitOfWorks
    {        
        private AppDbContext _appDbContext;
        public UnitOfWorks()
        {
            DbContextOptionsBuilder option = new DbContextOptionsBuilder();
            option.UseSqlServer(GlobalData.connectionStr);
            _appDbContext = new AppDbContext(option);          
        }
        public Itest TestRepository
        {
            get { return new Test(_appDbContext); }
        }
      

    }
}
