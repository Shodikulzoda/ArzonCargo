using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models.Enums;
using Stocky.WebApi.Infrastructure.Databases;
using Stocky.WebApi.Report.Dtos;
using Stocky.WebApi.Report.Repository.Interface;

namespace Stocky.WebApi.Report.Repository;

public class ReportRepository(ApplicationContext context) : IReportRepository
{
    public async Task<double> GetTotalEarnings(DateTime start, DateTime end)
    {
        return await context.Orders
            .Where(o => !o.IsDeleted && o.CreatedAt >= start && o.CreatedAt <= end)
            .SumAsync(o => o.TotalAmount);
    }

    public async Task<int> GetTotalProductsReceived(DateTime start, DateTime end)
    {
        return await context.OrderItems
            .Where(i => !i.IsDeleted && i.CreatedAt >= start && i.CreatedAt <= end)
            .CountAsync();
    }

    public async Task<int> GetCompletedPocketsCount(DateTime start, DateTime end)
    {
        return await context.Pockets
            .Where(p => !p.IsDeleted && p.CreatedAt >= start && p.CreatedAt <= end
                        && p.PocketItems.Any(i => !i.IsDeleted))
            .CountAsync();
    }

    public async Task<List<PaymentBreakdownDto>> GetPaymentBreakdown(DateTime start, DateTime end)
    {
        return await context.Orders
            .Where(o => !o.IsDeleted && o.CreatedAt >= start && o.CreatedAt <= end)
            .GroupBy(o => o.Method)
            .Select(g => new PaymentBreakdownDto
            {
                Method = g.Key,
                Total = g.Sum(x => x.TotalAmount)
            }).ToListAsync();
    }
}