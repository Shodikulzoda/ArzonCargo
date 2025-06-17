using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.ProductData.Commands.DeleteUser;

public record DeleteProductCommand : IRequest<ProductResponse>
{
    public int Id { get; set; }
}

public class DeleteUserHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<DeleteProductCommand, ProductResponse?>
{
    public async Task<ProductResponse?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        if (product is null)
        {
            return null;
        }

        await productRepository.Update(product);

        return mapper.Map<ProductResponse>(product);
    }
}