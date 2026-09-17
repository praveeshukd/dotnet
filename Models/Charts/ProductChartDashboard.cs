namespace ProductCrud.Models.Charts;

public record ChartPoint(string Label, decimal Value);

public record NamedSeries(string Name, IReadOnlyList<decimal> Values);

public class ProductChartDashboard
{
    public int TotalProducts { get; set; }
    public int TotalStock { get; set; }
    public decimal InventoryValue { get; set; }
    public int CategoryCount { get; set; }

    public IReadOnlyList<ChartPoint> ProductsByCategory { get; set; } = [];
    public IReadOnlyList<ChartPoint> StockByProduct { get; set; } = [];
    public IReadOnlyList<ChartPoint> InventoryValueByCategory { get; set; } = [];
    public IReadOnlyList<ChartPoint> PriceByProduct { get; set; } = [];
    public IReadOnlyList<ChartPoint> LowStockProducts { get; set; } = [];
}
