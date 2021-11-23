namespace ApartmentRentingSystem.Web
{
    using System.Threading.Tasks;
    using Application;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Common;

    
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator? mediator;

        protected IMediator Mediator
            => this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
        {
            return this.Mediator.Send(request).ToActionResult();
        }

        protected Task<ActionResult> Send(IRequest<Result> request)
        {
            return this.Mediator.Send(request).ToActionResult();
        }

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
        {
            return this.Mediator.Send(request).ToActionResult();
        }
    }
}