using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

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
            CreateMap<IndividualCustomer, IndividualCustomerResponse>();


            // GetById mapping
            CreateMap<IndividualCustomer, GetIndividualCustomerResponse>();

            // GetList mappings
            CreateMap<IndividualCustomer, GetIndividualCustomerListItemDto>();
            CreateMap<Paginate<IndividualCustomer>, GetListIndividualCustomerResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<IndividualCustomer, GetIndividualCustomerResponse>();
            CreateMap<IndividualCustomer, GetIndividualCustomerListItemDto>();
            CreateMap<Paginate<IndividualCustomer>, GetListIndividualCustomerResponse>();
            CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Request.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Request.LastName))
            .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.Request.NationalId))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Request.PhoneNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Request.Email))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Request.Address))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));
            

        }
    }
} 