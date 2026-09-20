using System.ComponentModel.DataAnnotations;

namespace ProductCrud.Models;

public class Book
{
    public int Id { get; set; }

    [StringLength(120)]
    public string? Author { get; set; } = string.Empty;

    [StringLength(120)]
    public string? Publisher { get; set; } = string.Empty;

    [StringLength(40)]
    public string? ISBN { get; set; } = string.Empty;

    [StringLength(80)]
    public string? Category { get; set; } = string.Empty;

    [StringLength(80)]
    public string? SubCategory { get; set; } = string.Empty;

    [StringLength(40)]
    public string? Language { get; set; } = string.Empty;
    [StringLength(40)]
    public string? Price { get; set; } = string.Empty;

}
