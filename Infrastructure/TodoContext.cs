using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class TodoContext: DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

        public class ETLContextDesignFactory : IDesignTimeDbContextFactory<TodoContext>
        {
            public TodoContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TodoContext>()
                    .UseSqlServer(@"Data Source=localhost;Initial Catalog=todoDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
                return new TodoContext(optionsBuilder.Options);
            }
        }
    }
}
