using ProductCrud.Models.Charts;

namespace ProductCrud.Services;

public interface IChartService
{
    Task<ProductChartDashboard> GetDashboardAsync(int lowStockThreshold = 20);
}
