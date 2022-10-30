using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.DeleteCompany;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Queries;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Queries.GetAllCompaniesListQuery;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
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



        [HttpGet( Name = "GetCompanies")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<CompaniesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompaniesVm>>> GetCompanies()
        {
            var query = new GetAllCompaniesListQuery();
            var inventories = await _mediator.Send(query);
            return Ok(inventories);
        }



        [HttpGet("{username}", Name = "GetCompany")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<CompaniesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompaniesVm>>> GetCompanyyUsername(string username)
        {
            var query = new GetCompaniesListQuery(username);
            var inventories = await _mediator.Send(query);
            return Ok(inventories);
        }
       
    }
}
