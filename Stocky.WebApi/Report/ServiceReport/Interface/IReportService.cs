using Stocky.WebApi.Report.Dtos;

namespace Stocky.WebApi.Report.ServiceReport.Interface;

public interface IReportService
{
    Task<ReportSummaryDto> GetSummaryAsync(DateTime start, DateTime end);
}