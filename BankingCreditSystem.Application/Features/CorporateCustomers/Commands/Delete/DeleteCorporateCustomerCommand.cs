using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;


namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete
{
    public class DeleteCorporateCustomerCommand : IRequest<DeletedCorporateCustomerResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeletedCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public DeleteCorporateCustomerCommandHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper,
            CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeletedCorporateCustomerResponse> Handle(DeleteCorporateCustomerCommand command, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExist(command.Id);

            var customerToDelete = await _corporateCustomerRepository.GetAsync(c => c.Id == command.Id);
            var deletedCustomer = await _corporateCustomerRepository.DeleteAsync(customerToDelete!);
            
            var response = _mapper.Map<DeletedCorporateCustomerResponse>(deletedCustomer);
            response.Message = CorporateCustomerMessages.CustomerDeleted;
            return response;
        }
    }
} 