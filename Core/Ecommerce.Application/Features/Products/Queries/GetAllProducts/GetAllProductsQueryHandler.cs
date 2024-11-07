using Ecommerce.Application.Interfaces.UnitOfWorks;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
            List<GetAllProductsQueryResponse> responses = new List<GetAllProductsQueryResponse>();
            foreach (var product in products)
            {
                responses.Add(new GetAllProductsQueryResponse
                {
                    Description = product.Description,
                    Discount = product.Discount,
                    Title = product.Title,
                    Price = product.Price - (product.Price * product.Discount / 100)
                });
            }
            return responses;
        }
    }
}
