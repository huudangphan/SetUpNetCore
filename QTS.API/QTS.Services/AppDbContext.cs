using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Entity;
using QTS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QTS.Services
{
    public class AppDbContext : DbContext
    {       
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TestEntity> TestEntities;
    }

}
