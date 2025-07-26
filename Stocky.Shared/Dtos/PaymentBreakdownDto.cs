using Stocky.Shared.Models.Enums;

namespace Stocky.Shared.Dtos;

public class PaymentBreakdownDto
{
    public PaymentMethod Method { get; set; }
    public double Total { get; set; }
}