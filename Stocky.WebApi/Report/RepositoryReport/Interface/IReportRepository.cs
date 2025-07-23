using Stocky.WebApi.Report.Dtos;

namespace Stocky.WebApi.Report.Repository.Interface;

public interface IReportRepository
{
    Task<double> GetTotalEarnings(DateTime start, DateTime end);
    Task<int> GetTotalProductsReceived(DateTime start, DateTime end);
    Task<int> GetCompletedPocketsCount(DateTime start, DateTime end);
    Task<List<PaymentBreakdownDto>> GetPaymentBreakdown(DateTime start, DateTime end);
}