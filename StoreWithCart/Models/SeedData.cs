using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreWithCart.Data;

namespace StoreWithCart.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StockContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StockContext>>()))
            {
                // Look for any movies.
                if (context.StockItem.Any())
                {
                    return;   // DB has been seeded
                }

                context.StockItem.AddRange(
                    new StockItem
                    {
                        Description = "Baguette",
                        Price = 3.49M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Small Wholemeal Loaf",
                        Price = 5.25M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Bannock",
                        Price = 3.75M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Millefuille",
                        Price = 4.50M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Bakewell Tart Slice",
                        Price = 3.50M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Blueberry Muffin",
                        Price = 2.50M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Linzer Torte Slice",
                        Price = 3.75M,
                        QuantityInCart = 0
                    },

                    new StockItem
                    {
                        Description = "Tarte au Sucre",
                        Price = 4.29M,
                        QuantityInCart = 0
                    }

                );
                context.SaveChanges();
            }
        }
    }
}

