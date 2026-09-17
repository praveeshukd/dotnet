using ProductCrud.Models;

namespace ProductCrud.Repositories;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllAsync(string? search = null, int? categoryId = null, bool activeOnly = true);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
