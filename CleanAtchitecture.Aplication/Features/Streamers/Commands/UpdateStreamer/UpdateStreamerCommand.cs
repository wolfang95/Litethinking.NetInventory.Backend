﻿using MediatR;


namespace Litethinking.NetInventory.Backend.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
