using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Entity;
using QTS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using QTS.Commons;
namespace QTS.Services
{
    public class AppDbContext : DbContext
    {
               
        public AppDbContext(DbContextOptionsBuilder options)
        {            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlServer(GlobalData.connectionStr);

        public DbSet<TestEntity> TestEntity { get; set; }
        
    }

}
