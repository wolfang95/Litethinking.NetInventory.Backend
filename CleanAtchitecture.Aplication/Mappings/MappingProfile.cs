using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Features.Directors.Commands.CreateDirector;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using Litethinking.NetInventory.Backend.Domain;

namespace Litethinking.NetInventory.Backend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Inventory, InventoriesVm>();
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
            CreateMap<CreateDirectorCommand, Director>();
            
        }
    }
}
