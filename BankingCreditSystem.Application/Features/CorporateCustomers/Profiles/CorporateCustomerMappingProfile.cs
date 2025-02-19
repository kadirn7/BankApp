using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;


namespace BankingCreditSystem.Application.Features.CorporateCustomers.Profiles
{
    public class CorporateCustomerMappingProfile : Profile
    {
        public CorporateCustomerMappingProfile()
        {
            // Create mappings
            CreateMap<CreateCorporateCustomerRequest, CorporateCustomer>();
            CreateMap<CorporateCustomer, CreatedCorporateCustomerResponse>();

            // Update mappings
            CreateMap<UpdateCorporateCustomerRequest, CorporateCustomer>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore());
            
            CreateMap<CorporateCustomer, UpdatedCorporateCustomerResponse>();

            // Delete mapping
            CreateMap<CorporateCustomer, DeletedCorporateCustomerResponse>();

            // GetById mapping
            CreateMap<CorporateCustomer, GetCorporateCustomerResponse>();

            // GetList mappings
            CreateMap<CorporateCustomer, GetCorporateCustomerListItemDto>();
            CreateMap<Paginate<CorporateCustomer>, GetListCorporateCustomerResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
} 