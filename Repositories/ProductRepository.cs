using Microsoft.EntityFrameworkCore;
using ProductCrud.Data;
using ProductCrud.Models;

namespace ProductCrud.Repositories;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllAsync(
        string? search = null,
        int? categoryId = null,
        bool activeOnly = true)
    {
        var query = db.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .AsQueryable();

        if (activeOnly)
        {
            query = query.Where(p => p.IsActive);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(term) ||
                (p.Description != null && p.Description.ToLower().Contains(term)));
        }

        if (categoryId is > 0)
        {
            query = query.Where(p => p.CategoryId == categoryId);
        }

        return await query
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await db.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        product.CreatedAt = DateTime.UtcNow;
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        var existing = await db.Products.FindAsync(product.Id);
        if (existing is null)
        {
            return;
        }

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.Stock = product.Stock;
        existing.CategoryId = product.CategoryId;
        existing.IsActive = product.IsActive;

        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null)
        {
            return;
        }

        // Soft delete — keeps history, safer for intermediate CRUD demos
        product.IsActive = false;
        await db.SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(int id)
    {
        return db.Products.AnyAsync(p => p.Id == id);
    }
}
