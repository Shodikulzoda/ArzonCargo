using Stocky.WebApi.Report.Dtos;
using Stocky.WebApi.Report.Repository.Interface;
using Stocky.WebApi.Report.ServiceReport.Interface;

namespace Stocky.WebApi.Report.ServiceReport;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;

    public ReportService(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReportSummaryDto> GetSummaryAsync(DateTime start, DateTime end)
    {
        var earnings = await _repository.GetTotalEarnings(start, end);
        var products = await _repository.GetTotalProductsReceived(start, end);
        var pockets = await _repository.GetCompletedPocketsCount(start, end);
        var payment = await _repository.GetPaymentBreakdown(start, end);

        return new ReportSummaryDto
        {
            TotalEarnings = earnings,
            ProductsReceived = products,
            CompletedPockets = pockets,
            PaymentBreakdown = payment
        };
    }
}