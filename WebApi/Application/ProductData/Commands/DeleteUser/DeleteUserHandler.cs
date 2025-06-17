using MediatR;
using WebApi.Application.Interfaces;

namespace WebApi.Application.ProductData.Commands.DeleteUser;

public record DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteUserHandler(IProductRepository productRepository)
    : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await productRepository.Delete(request.Id);
    }
}