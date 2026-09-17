using ProductCrud.Models;
using ProductCrud.Repositories;

namespace ProductCrud.Services;

/// <summary>
/// Business rules live here — Blazor pages stay thin and only call this service.
/// </summary>
public class ProductService(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository) : IProductService
{
    public Task<IReadOnlyList<Product>> GetProductsAsync(string? search = null, int? categoryId = null)
        => productRepository.GetAllAsync(search, categoryId);

    public Task<Product?> GetProductAsync(int id)
        => productRepository.GetByIdAsync(id);

    public async Task<(bool Success, string? Error)> CreateAsync(Product product)
    {
        var error = await ValidateAsync(product);
        if (error is not null)
        {
            return (false, error);
        }

        product.Name = product.Name.Trim();
        product.Description = string.IsNullOrWhiteSpace(product.Description)
            ? null
            : product.Description.Trim();

        await productRepository.AddAsync(product);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> UpdateAsync(Product product)
    {
        if (!await productRepository.ExistsAsync(product.Id))
        {
            return (false, "Product not found.");
        }

        var error = await ValidateAsync(product);
        if (error is not null)
        {
            return (false, error);
        }

        product.Name = product.Name.Trim();
        product.Description = string.IsNullOrWhiteSpace(product.Description)
            ? null
            : product.Description.Trim();

        await productRepository.UpdateAsync(product);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DeleteAsync(int id)
    {
        if (!await productRepository.ExistsAsync(id))
        {
            return (false, "Product not found.");
        }

        await productRepository.DeleteAsync(id);
        return (true, null);
    }

    public Task<IReadOnlyList<Category>> GetCategoriesAsync()
        => categoryRepository.GetAllAsync();

    private async Task<string?> ValidateAsync(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            return "Product name is required.";
        }

        if (product.Price <= 0)
        {
            return "Price must be greater than zero.";
        }

        if (product.Stock < 0)
        {
            return "Stock cannot be negative.";
        }

        var category = await categoryRepository.GetByIdAsync(product.CategoryId);
        if (category is null)
        {
            return "Selected category does not exist.";
        }

        return null;
    }
}
