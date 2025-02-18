using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update
{
    public class UpdateIndividualCustomerCommand : IRequest<UpdatedIndividualCustomerResponse>
    {
        public UpdateIndividualCustomerRequest Request { get; set; } = null!;
    }

    public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdatedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public UpdateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdatedIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand command, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExist(command.Request.Id);

            var existingCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == command.Request.Id);
            
            _mapper.Map(command.Request, existingCustomer);
            var updatedCustomer = await _individualCustomerRepository.UpdateAsync(existingCustomer!);
            
            return _mapper.Map<UpdatedIndividualCustomerResponse>(updatedCustomer);
        }
    }
} 