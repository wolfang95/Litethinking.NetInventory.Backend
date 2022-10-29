using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList
{
    public class GetInventoriesListQuery : IRequest<List<InventoriesVm>>
    {
        public string _Username { get; set; } = String.Empty;
        public GetInventoriesListQuery(string username)
        {
            _Username = username ?? throw new ArgumentException(nameof(username));
        }
    }
}
