using MediatR;
using AutoMapper;


namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList
{
    public class GetListCorporateCustomerQuery : IRequest<GetListCorporateCustomerResponse>
    {
        public GetListCorporateCustomerRequest Request { get; set; } = null!;
    }

    public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, GetListCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public GetListCorporateCustomerQueryHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
        }

        public async Task<GetListCorporateCustomerResponse> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _corporateCustomerRepository.GetListAsync(
                index: request.Request.Index,
                size: request.Request.Size,
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            return _mapper.Map<GetListCorporateCustomerResponse>(customers);
        }
    }
} 