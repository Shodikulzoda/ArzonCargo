using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.Services;

public record PriceChangerCommand : IRequest<double>
{
    public double newPrice { get; set; }
}

public class PriceChangerHandler(IPriceListRepository priceListRepository)
    : IRequestHandler<PriceChangerCommand, double>
{
    public async Task<double> Handle(PriceChangerCommand request, CancellationToken cancellationToken)
    {
        if (request is not null && request.newPrice <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        var priceList = new PriceList
        {
            PricePerKg = request.newPrice
        };
        var addAsync = await priceListRepository.AddAsync(priceList);

        if (addAsync)
            return request.newPrice;

        throw new InvalidOperationException("Failed to change the price.");
    }
}

public record PriceChangerGetPriceQuery : IRequest<PriceList?>;

public class PriceChangerGetByIdHandler(IPriceListRepository priceListRepository)
    : IRequestHandler<PriceChangerGetPriceQuery, PriceList?>
{
    public async Task<PriceList?> Handle(PriceChangerGetPriceQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var priceList = await priceListRepository.GetPriceAsync();

        if (priceList is null)
        {
            throw new KeyNotFoundException("Price not found.");
        }

        return priceList;
    }
}

public record PriceChangerGetAllQuery : IRequest<IEnumerable<PriceList>>;

public class PriceChangerGetAllHandler(IPriceListRepository priceListRepository)
    : IRequestHandler<PriceChangerGetAllQuery, IEnumerable<PriceList>>
{
    public async Task<IEnumerable<PriceList>> Handle(PriceChangerGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await priceListRepository.GetAllAsync();
    }
}