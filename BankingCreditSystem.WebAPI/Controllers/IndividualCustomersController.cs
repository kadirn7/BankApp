using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class IndividualCustomersController : BaseController
    {
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdIndividualCustomerQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListIndividualCustomerQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteIndividualCustomerCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}