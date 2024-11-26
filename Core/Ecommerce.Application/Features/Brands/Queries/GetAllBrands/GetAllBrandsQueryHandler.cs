using Ecommerce.Application.Bases;
using Ecommerce.Application.Interfaces.AutoMapper;
using Ecommerce.Application.Interfaces.UnitOfWorks;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler, IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Brand> brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            return mapper.Map<GetAllBrandsQueryResponse,Brand>(brands);
        }
    }
}
