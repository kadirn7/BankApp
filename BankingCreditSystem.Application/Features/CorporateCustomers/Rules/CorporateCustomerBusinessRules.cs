namespace BankingCreditSystem.Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task TaxNumberCannotBeDuplicated(string taxNumber)
        {
            var customer = await _corporateCustomerRepository.GetAsync(c => c.TaxNumber == taxNumber);
            if (customer != null)
                throw new BusinessException(CorporateCustomerMessages.TaxNumberAlreadyExists);
        }

        public async Task CustomerShouldExist(Guid id)
        {
            var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == id);
            if (customer == null)
                throw new BusinessException(CorporateCustomerMessages.CustomerNotFound);
        }
    }
} 