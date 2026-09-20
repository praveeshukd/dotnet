using Microsoft.AspNetCore.Mvc;

namespace ProductCrud.Controllers;

[ApiController]
[Route("api/simpleapi")]
public class SimpleApiController : ControllerBase
{
    // In-memory sample data for demonstration
    private static readonly List<SimpleItem> Items = new()
    {
        new SimpleItem { Id = 1, Name = "Sample Item 1", Price = 19.99m },
        new SimpleItem { Id = 2, Name = "Sample Item 2", Price = 29.99m }
    };

    // GET: api/simpleapi
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Items);
    }

    // GET: api/simpleapi/1
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound(new { message = $"Item with Id {id} not found." });
        }
        return Ok(item);
    }

    // POST: api/simpleapi
    [HttpPost]
    public IActionResult Create([FromBody] SimpleItem newItem)
    {
        if (string.IsNullOrWhiteSpace(newItem.Name))
        {
            return BadRequest(new { message = "Item name is required." });
        }

        newItem.Id = Items.Count > 0 ? Items.Max(i => i.Id) + 1 : 1;
        Items.Add(newItem);

        return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
    }

    // PUT: api/simpleapi/1
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] SimpleItem updatedItem)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound(new { message = $"Item with Id {id} not found." });
        }

        item.Name = updatedItem.Name;
        item.Price = updatedItem.Price;

        return NoContent();
    }

    // DELETE: api/simpleapi/1
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound(new { message = $"Item with Id {id} not found." });
        }

        Items.Remove(item);
        return NoContent();
    }
}

public class SimpleItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
