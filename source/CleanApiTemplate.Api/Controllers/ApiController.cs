using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiTemplate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
