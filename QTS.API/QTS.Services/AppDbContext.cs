using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Entity;
using QTS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace QTS.Services
{
    public class AppDbContext : DbContext
    {
               
        public AppDbContext(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=PC;Initial Catalog=Test;Integrated Security=True");
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlServer(@"Data Source=PC;Initial Catalog=Test;Integrated Security=True");

        public DbSet<TestEntity> TestEntity { get; set; }
        
    }

}
