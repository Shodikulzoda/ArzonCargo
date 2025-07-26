using Stocky.Shared.Dtos;
using Stocky.WebApi.Report.RepositoryReport.Interface;
using Stocky.WebApi.Report.ServiceReport.Interface;

namespace Stocky.WebApi.Report.ServiceReport;

public class ReportService(IReportRepository repository) : IReportService
{
    public async Task<ReportSummaryDto> GetSummaryAsync(DateTime start, DateTime end)
    {
        var earnings = await repository.GetTotalEarnings(start, end);
        var products = await repository.GetTotalProductsReceived(start, end);
        var newProducts = await repository.NewProducts(start, end);
        var payment = await repository.GetPaymentBreakdown(start, end);

        return new ReportSummaryDto
        {
            TotalEarnings = earnings,
            NewProducts = newProducts,
            ProductsReceived = products,
            PaymentBreakdown = payment
        };
    }
}