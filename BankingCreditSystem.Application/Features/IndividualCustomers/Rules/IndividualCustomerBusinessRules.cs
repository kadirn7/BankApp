

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task CustomerShouldExist(Guid id)
        {
            var customer = await _individualCustomerRepository.GetAsync(c => c.Id == id);
           // if (customer == null) throw new BusinessException(IndividualCustomerMessages.CustomerNotFound);
        }

        public async Task NationalIdCannotBeDuplicated(string nationalId)
        {
            var result = await _individualCustomerRepository.AnyAsync(c => c.NationalId == nationalId);
          //  if (result) throw new BusinessException(IndividualCustomerMessages.NationalIdAlreadyExists);
        }
    }
} 