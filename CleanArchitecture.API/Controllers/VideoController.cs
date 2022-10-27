using Litethinking.NetInventory.Backend.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Litethinking.NetInventory.Backend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetVideo")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<VideosVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VideosVm>>> GetVideosByUsername(string username)
        {
            var query = new GetVideosListQuery(username);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }

}
