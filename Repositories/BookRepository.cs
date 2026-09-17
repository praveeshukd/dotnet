using Microsoft.EntityFrameworkCore;
using ProductCrud.Data;
using ProductCrud.Models;

namespace ProductCrud.Repositories;

public class BookRepository(AppDbContext db)
{
    public async Task AddAsync(Book book)
    {
        db.Books.Add(book);
        await db.SaveChangesAsync();
    }

    public Task<List<Book>> GetAllAsync()
        => db.Books.AsNoTracking().ToListAsync();
}
