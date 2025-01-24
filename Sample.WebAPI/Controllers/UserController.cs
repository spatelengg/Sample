using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.WebAPI.Controllers.Base;


namespace Sample.WebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Application.UseCases.UserCreation.UserCreationResponse>> Create(
            Application.UseCases.UserCreation.UserCreationRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Application.UseCases.UserApproval.UserApprovalResponse>> Approve(
          Application.UseCases.UserApproval.UserApprovalRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Application.UseCases.UserRegistration.UserRegistrationResponse>> Register(
         Application.UseCases.UserRegistration.UserRegistrationRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
