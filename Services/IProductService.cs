using ProductCrud.Models;

namespace ProductCrud.Services;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetProductsAsync(string? search = null, int? categoryId = null);
    Task<Product?> GetProductAsync(int id);
    Task<(bool Success, string? Error)> CreateAsync(Product product);
    Task<(bool Success, string? Error)> UpdateAsync(Product product);
    Task<(bool Success, string? Error)> DeleteAsync(int id);
    Task<IReadOnlyList<Category>> GetCategoriesAsync();
}
