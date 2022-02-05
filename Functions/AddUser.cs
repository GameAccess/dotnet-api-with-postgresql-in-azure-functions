using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using Company.Function.Messages;
using System.IO;
using Newtonsoft.Json;

namespace Company.Function
{
    public class AddUser
    {
        private readonly IMediator _mediator;

        public AddUser(IMediator mediator) => 
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [FunctionName("add-user")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var request = JsonConvert.DeserializeObject<AddUserRequest>(requestBody);
                var user = await _mediator.Send(request);
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                log.LogError($"Couldn't insert user. Exception thrown: {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
