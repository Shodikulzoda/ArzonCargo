using MediatR;
using Stocky.Shared.Dtos;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.ReportData.Commands;

public record GetReportCommand(DateTime StartDate, DateTime EndDate) : IRequest<ReportSummaryDto>;

public class GetReporHandler(IReportRepository reportRepository) : IRequestHandler<GetReportCommand, ReportSummaryDto>
{
    public async Task<ReportSummaryDto> Handle(GetReportCommand request, CancellationToken cancellationToken)
    {
        var earnings = await reportRepository.GetTotalEarnings(request.StartDate, request.EndDate);
        var products = await reportRepository.GetTotalProductsReceived(request.StartDate, request.EndDate);
        var newProducts = await reportRepository.NewProducts(request.StartDate, request.EndDate);
        var payment = await reportRepository.GetPaymentBreakdown(request.StartDate, request.EndDate);

        return new ReportSummaryDto
        {
            TotalEarnings = earnings,
            NewProducts = newProducts,
            ProductsReceived = products,
            PaymentBreakdown = payment
        };
    }
}