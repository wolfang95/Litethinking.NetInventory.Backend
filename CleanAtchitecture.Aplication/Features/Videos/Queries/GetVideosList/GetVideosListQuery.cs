﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = String.Empty;
        public GetVideosListQuery(string username)
        {
            _Username = username ?? throw new ArgumentException(nameof(username));
        }
    }
}
