using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;


namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>
    {
        public CreateIndividualCustomerRequest Request { get; set; } = null!;
    }

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicated(request.Request.NationalId);

            var individualCustomer = _mapper.Map<IndividualCustomer>(request.Request);
            var createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);
            
            return _mapper.Map<CreatedIndividualCustomerResponse>(createdCustomer);
        }
    }
} 