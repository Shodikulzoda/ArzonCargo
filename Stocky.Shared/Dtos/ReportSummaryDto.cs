namespace Stocky.Shared.Dtos;

public class ReportSummaryDto
{
    public double TotalEarnings { get; set; }
    public int NewProducts { get; set; }
    public int ProductsReceived { get; set; }
    public List<PaymentBreakdownDto> PaymentBreakdown { get; set; } = new();
}