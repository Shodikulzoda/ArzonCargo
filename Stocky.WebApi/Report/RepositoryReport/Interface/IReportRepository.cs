using Stocky.Shared.Dtos;

namespace Stocky.WebApi.Report.RepositoryReport.Interface;

public interface IReportRepository
{
    Task<double> GetTotalEarnings(DateTime start, DateTime end);
    Task<int> GetTotalProductsReceived(DateTime start, DateTime end);
    Task<int> NewProducts(DateTime start, DateTime end);
    Task<List<PaymentBreakdownDto>> GetPaymentBreakdown(DateTime start, DateTime end);
}