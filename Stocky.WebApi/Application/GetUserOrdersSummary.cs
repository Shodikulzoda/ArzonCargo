using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;
using System;

namespace Stocky.WebApi.Application;

public class OrderSummaryDto
{
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public List<Order> Orders { get; set; } = new();
}

public class GetUserOrdersSummaryQuery : IRequest<OrderSummaryDto>
{
    public int UserId { get; set; }
    public DateTime? Date { get; set; }
}

public class GetUserOrdersSummaryHandler : IRequestHandler<GetUserOrdersSummaryQuery, OrderSummaryDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetUserOrdersSummaryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderSummaryDto> Handle(GetUserOrdersSummaryQuery request, CancellationToken cancellationToken)
    {
        var query = _orderRepository.Queryable.Where(o => o.UserId == request.UserId && !o.IsDeleted);

        if (request.Date.HasValue)
        {
            // Convert date to UTC boundaries of that day:
            var selectedDateUtc = request.Date.Value.Date.ToUniversalTime();
            var nextDateUtc = selectedDateUtc.AddDays(1);

            // Filter CreatedAt between start and end of the day in UTC
            query = query.Where(o => o.CreatedAt >= selectedDateUtc && o.CreatedAt < nextDateUtc);
        }

        var orders = await query.ToListAsync(cancellationToken);

        return new OrderSummaryDto
        {
            TotalAmount = orders.Sum(o => o.TotalAmount),
            TotalWeight = orders.Sum(o => o.TotalWeight),
            Orders = orders
        };
    }
}