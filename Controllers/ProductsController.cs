using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using ProductCrud.Services;

namespace ProductCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetAll(
        [FromQuery] string? search = null,
        [FromQuery] int? categoryId = null)
    {
        var products = await productService.GetProductsAsync(search, categoryId);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await productService.GetProductAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] Product product)
    {
        var (success, error) = await productService.CreateAsync(product);
        if (!success)
        {
            return BadRequest(new { error });
        }

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            product.Id = id;
        }

        var (success, error) = await productService.UpdateAsync(product);
        if (!success)
        {
            return error == "Product not found." ? NotFound(new { error }) : BadRequest(new { error });
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var (success, error) = await productService.DeleteAsync(id);
        if (!success)
        {
            return NotFound(new { error });
        }

        return NoContent();
    }
}
