using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Dtos;
using Stocky.WebApi.Infrastructure.Databases;
using Stocky.WebApi.Report.RepositoryReport.Interface;

namespace Stocky.WebApi.Report.RepositoryReport;

public class ReportRepository(ApplicationContext context) : IReportRepository
{
    public async Task<double> GetTotalEarnings(DateTime start, DateTime end)
    {
        var sumAsync = await context.Orders
            .Where(o => !o.IsDeleted && o.CreatedAt >= start && o.CreatedAt <= end)
            .SumAsync(o => o.TotalAmount);

        return sumAsync;
    }

    public async Task<int> GetTotalProductsReceived(DateTime start, DateTime end)
    {
        var countAsync = await context.OrderItems
            .Where(i => !i.IsDeleted && i.CreatedAt >= start && i.CreatedAt <= end)
            .CountAsync();

        return countAsync;
    }

    public async Task<int> NewProducts(DateTime start, DateTime end)
    {
        var countAsync = await context.Products
            .Where(i => !i.IsDeleted && i.CreatedAt >= start && i.CreatedAt <= end)
            .CountAsync();

        return countAsync;
    }

    public async Task<List<PaymentBreakdownDto>> GetPaymentBreakdown(DateTime start, DateTime end)
    {
        var paymentBreakdownDtos = await context.Orders
            .Where(o => !o.IsDeleted && o.CreatedAt >= start && o.CreatedAt <= end)
            .GroupBy(o => o.Method)
            .Select(g => new PaymentBreakdownDto
            {
                Method = g.Key,
                Total = g.Sum(x => x.TotalAmount)
            }).ToListAsync();

        return paymentBreakdownDtos;
    }
}