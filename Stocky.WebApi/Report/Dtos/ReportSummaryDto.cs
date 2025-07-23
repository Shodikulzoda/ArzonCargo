namespace Stocky.WebApi.Report.Dtos;

public class ReportSummaryDto
{
    public double TotalEarnings { get; set; }
    public int ProductsReceived { get; set; }
    public int CompletedPockets { get; set; }

    public List<PaymentBreakdownDto> PaymentBreakdown { get; set; } = new();
}