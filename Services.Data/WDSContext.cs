using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Data
{
    public class WDSContext: DbContext
    {

        public WDSContext(DbContextOptions<WDSContext> options) : base(options)
        {
        }
        public DbSet<TestEntity> TestEntities { get; set; }


        public class ETLContextDesignFactory : IDesignTimeDbContextFactory<WDSContext>
        {
            public WDSContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<WDSContext>()
                    .UseSqlServer(@"Data Source=localhost;Initial Catalog=testDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
                return new WDSContext(optionsBuilder.Options);
            }
        }
    }
}
