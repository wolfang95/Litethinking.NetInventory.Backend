﻿using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Features.Reports.Commands.CreateReport;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Application.Features.Companies.Queries;

namespace Litethinking.NetInventory.Backend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Inventory, InventoriesVm>();
            CreateMap<Company, CompaniesVm>();
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
            CreateMap<CreateReportCommand, Report>();
            
        }
    }
}
