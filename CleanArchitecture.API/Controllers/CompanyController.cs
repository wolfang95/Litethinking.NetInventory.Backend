

using Litethinking.NetInventory.Backend.Application.Features.Company.Queries;
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

        [HttpGet("{username}", Name = "GetVideo")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<CompaniesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompaniesVm>>> GetVideosByUsername(string username)
        {
            var query = new GetCompaniesListQuery(username);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }


    }
}
