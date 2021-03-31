using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TodoContextSeed
    {
        public static async Task SeedAsync(TodoContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Categories.Any())
                {
                    var categoryData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);
                    foreach (var category in categories)
                    {
                        // var b = new Category { Name = category.Name };
                        context.Categories.Add(category);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Todos.Any())
                {
                    var todoData = File.ReadAllText("../Infrastructure/Data/SeedData/todos.json");
                    var todos = JsonSerializer.Deserialize<List<Todo>>(todoData);

                    foreach (var todo in todos)
                    {
                        //var p = new Product
                        //{
                        //    Name = product.Name,
                        //    Description = product.Description,
                        //    PictureUrl = product.PictureUrl,
                        //    Price = product.Price,
                        //    ProductBrand = product.ProductBrand,
                        //    ProductBrandId = product.ProductBrandId,
                        //    ProductType = product.ProductType,
                        //    ProductTypeId = product.ProductTypeId
                        //};
                        context.Todos.Add(todo);
                    }
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<TodoContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
