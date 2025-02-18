using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create
{
    public class CreateCorporateCustomerCommand : IRequest<CreatedCorporateCustomerResponse>
    {
        public CreateCorporateCustomerRequest Request { get; set; } = null!;
    }

    public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreatedCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public CreateCorporateCustomerCommandHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper,
            CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.TaxNumberCannotBeDuplicated(request.Request.TaxNumber);

            var corporateCustomer = _mapper.Map<CorporateCustomer>(request.Request);
            var createdCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);
            
            return _mapper.Map<CreatedCorporateCustomerResponse>(createdCustomer);
        }
    }
} 