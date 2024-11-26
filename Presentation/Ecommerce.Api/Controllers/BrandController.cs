using Ecommerce.Application.Features.Brands.Commands.CreateBrand;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Ecommerce.Application.Features.Brands.Queries.GetAllBrands;
namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok(StatusCodes.Status201Created);
        } 
        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(response);
        }
    }
}
