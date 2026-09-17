using ProductCrud.Models;
using ProductCrud.Repositories;

namespace ProductCrud.Services;

public class BookService(BookRepository repo)
{
    public async Task<(bool Ok, string? Error)> CreateAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Author))
        {
            return (false, "Author required");
        }

        await repo.AddAsync(book);
        return (true, null);
    }

    public Task<List<Book>> GetAllAsync()
        => repo.GetAllAsync();
}
