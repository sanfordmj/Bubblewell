using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private ISender? _sender;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();

    }
}
