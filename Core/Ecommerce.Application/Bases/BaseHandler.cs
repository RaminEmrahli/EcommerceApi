using Ecommerce.Application.Interfaces.AutoMapper;
using Ecommerce.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Bases
{
    public class BaseHandler
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly string UserId;

        public BaseHandler(IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            UserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
