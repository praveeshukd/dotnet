using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using ProductCrud.Services;

namespace ProductCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(BookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAll()
    {
        var books = await bookService.GetAllAsync();
        return Ok(books);
    }
   
  

    [HttpPost]
    public async Task<ActionResult<Book>> Create([FromBody] Book book)
    {
        var (ok, error) = await bookService.CreateAsync(book);
        if (!ok)
        {
            return BadRequest(new { error });
        }

        return CreatedAtAction(nameof(GetAll), new { id = book.Id }, book);
    }
    [HttpGet("test")]
    public IActionResult Test()
    {
        int price = 100;
        string name = "Laptop";

        return Ok(new
        {
            Name = name,
            Price = price
        });
    }


     

 
}
