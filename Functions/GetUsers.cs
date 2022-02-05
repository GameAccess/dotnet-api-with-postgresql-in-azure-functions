using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using Company.Function.Messages;

namespace Company.Function
{
    public class GetUsers
    {
        private readonly IMediator _mediator;

        public GetUsers(IMediator mediator) => 
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [FunctionName("get-users")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var users = await _mediator.Send(new GetUsersRequest());
            return new OkObjectResult(users);
        }
    }
}
