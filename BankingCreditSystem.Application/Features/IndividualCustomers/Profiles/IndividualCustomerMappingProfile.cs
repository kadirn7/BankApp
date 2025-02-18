using AutoMapper;


namespace BankingCreditSystem.Application.Features.IndividualCustomers.Profiles
{
    public class IndividualCustomerMappingProfile : Profile
    {
        public IndividualCustomerMappingProfile()
        {
            // Create mappings
            CreateMap<CreateIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, CreatedIndividualCustomerResponse>();

            // Update mappings
            CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore());
                
            CreateMap<IndividualCustomer, UpdatedIndividualCustomerResponse>();

            // Delete mapping
            CreateMap<IndividualCustomer, DeletedIndividualCustomerResponse>();

            // GetById mapping
            CreateMap<IndividualCustomer, GetIndividualCustomerResponse>();

            // GetList mappings
            CreateMap<IndividualCustomer, GetIndividualCustomerListItemDto>();
            CreateMap<Paginate<IndividualCustomer>, GetListIndividualCustomerResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
} 