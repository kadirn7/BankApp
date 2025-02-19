using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById
{
    public class GetByIdCorporateCustomerQuery : IRequest<GetCorporateCustomerResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdCorporateCustomerQueryHandler : IRequestHandler<GetByIdCorporateCustomerQuery, GetCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public GetByIdCorporateCustomerQueryHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper,
            CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetCorporateCustomerResponse> Handle(GetByIdCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExist(request.Id);

            var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
            return _mapper.Map<GetCorporateCustomerResponse>(customer);
        }
    }
} 