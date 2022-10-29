using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.DeleteCompany;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Litethinking.NetInventory.Backend.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {

        private IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateCompany")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCompany([FromBody] CreateCompanyCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCompany([FromBody] UpdateCompanyCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var command = new DeleteCompanyCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
