using MediatR;
using AutoMapper;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList
{
    public class GetListIndividualCustomerQuery : IRequest<GetListIndividualCustomerResponse>
    {
        public GetListIndividualCustomerRequest Request { get; set; } = null!;
    }

    public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, GetListIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetListIndividualCustomerQueryHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<GetListIndividualCustomerResponse> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _individualCustomerRepository.GetListAsync(
                index: request.Request.Index,
                size: request.Request.Size,
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map<GetListIndividualCustomerResponse>(customers);
            return response;
        }
    }
} 