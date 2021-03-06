using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {

            try
            {
                if(!context.ProductBrands.Any())
                {

                    var brandsData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach(var items in brands)
                    {
                        context.ProductBrands.Add(items);
                        
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.ProductTypes.Any())
                {

                    var brandsType=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types=JsonSerializer.Deserialize<List<ProductType>>(brandsType);
                    foreach(var items in types)
                    {
                        context.ProductTypes.Add(items);
                        
                    }
                    await context.SaveChangesAsync();
                }

                  if(!context.Products.Any())
                {

                    var productsData=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products=JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach(var items in products)
                    {
                        context.Products.Add(items);
                        
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }        
        }
    }
}