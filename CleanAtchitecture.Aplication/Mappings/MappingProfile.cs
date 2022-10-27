using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Features.Directors.Commands.CreateDirector;
using Litethinking.NetInventory.Backend.Application.Features.Streamers.Commands;
using Litethinking.NetInventory.Backend.Application.Features.Streamers.Commands.UpdateStreamer;
using Litethinking.NetInventory.Backend.Application.Features.Videos.Queries.GetVideosList;
using Litethinking.NetInventory.Backend.Domain;

namespace Litethinking.NetInventory.Backend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<UpdateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
        }
    }
}
