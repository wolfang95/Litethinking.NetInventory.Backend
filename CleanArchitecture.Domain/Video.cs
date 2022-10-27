﻿using Litethinking.NetInventory.Backend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Domain
{
    public class Video : BaseDomainModel
    {
        public Video()
        {
            Actores = new HashSet<Actor>();
        }
        public string? Name { get; set; }

        public int? StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor> Actores { get; set; }
        public virtual Director Director { get; set; }


    }
}
