using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using ProductCrud.Services;

namespace ProductCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetAll()
    {
        var categories = await productService.GetCategoriesAsync();
        return Ok(categories);
    }
}
