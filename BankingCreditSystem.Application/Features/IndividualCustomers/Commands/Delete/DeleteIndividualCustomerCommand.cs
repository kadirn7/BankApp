using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Delete
{
    public class DeleteIndividualCustomerCommand : IRequest<DeletedIndividualCustomerResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeletedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public DeleteIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeletedIndividualCustomerResponse> Handle(DeleteIndividualCustomerCommand command, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExist(command.Id);

            var customerToDelete = await _individualCustomerRepository.GetAsync(c => c.Id == command.Id);
            var deletedCustomer = await _individualCustomerRepository.DeleteAsync(customerToDelete!);
            
            return _mapper.Map<DeletedIndividualCustomerResponse>(deletedCustomer);
        }
    }
} 