using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetByIdList;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Litethinking.NetInventory.Backend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetInventory")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<InventoriesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InventoriesVm>>> GetInventoriesByUsername(string username)
        {
            var query = new GetInventoriesListQuery(username);
            var inventories = await _mediator.Send(query);
            return Ok(inventories);
        }

        [HttpGet("company/{companyid}", Name = "GetInventoryCompany")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<InventoriesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InventoriesVm>>> GetInventoriesByCompanyId(int companyId)
        {
            var query = new GetInventoriesbyCompanyIdListQuery(companyId);
            var inventories = await _mediator.Send(query);
            return Ok(inventories);
        }

    }

}
