using Microsoft.EntityFrameworkCore;
using ProductCrud.Models;

namespace ProductCrud.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext db)
    {
        // Use migrations (not EnsureCreated) so EF can track schema changes.
        db.Database.Migrate();

        if (db.Categories.Any())
        {
            return;
        }

        var electronics = new Category { Name = "Electronics", Description = "Gadgets and devices" };
        var books = new Category { Name = "Books", Description = "Printed and digital books" };
        var clothing = new Category { Name = "Clothing", Description = "Apparel and accessories" };

        db.Categories.AddRange(electronics, books, clothing);
        db.SaveChanges();

        db.Products.AddRange(
            new Product
            {
                Name = "Wireless Mouse",
                Description = "Ergonomic Bluetooth mouse",
                Price = 29.99m,
                Stock = 50,
                CategoryId = electronics.Id
            },
            new Product
            {
                Name = "USB-C Hub",
                Description = "7-in-1 multiport adapter",
                Price = 49.50m,
                Stock = 30,
                CategoryId = electronics.Id
            },
            new Product
            {
                Name = "C# in Depth",
                Description = "Intermediate C# reference",
                Price = 44.00m,
                Stock = 20,
                CategoryId = books.Id
            },
            new Product
            {
                Name = "Hoodie",
                Description = "Cotton blend hoodie",
                Price = 39.99m,
                Stock = 15,
                CategoryId = clothing.Id
            }
        );

        db.SaveChanges();
    }
}
