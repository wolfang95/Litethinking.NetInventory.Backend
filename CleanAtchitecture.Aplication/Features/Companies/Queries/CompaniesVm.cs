using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Queries
{
    public class CompaniesVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
    }
}
