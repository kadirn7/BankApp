using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById
{
    public class GetByIdCorporateCustomerQuery : IRequest<GetCorporateCustomerResponse>
    {
        public GetByIdCorporateCustomerRequest Request { get; set; } = null!;
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
            await _businessRules.CustomerShouldExist(request.Request.Id);

            var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Request.Id);
            return _mapper.Map<GetCorporateCustomerResponse>(customer);
        }
    }
} 