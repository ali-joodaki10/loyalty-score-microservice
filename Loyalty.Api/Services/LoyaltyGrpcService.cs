using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using Grpc.Core;
using Loyalty.Api.Extensions;

namespace Loyalty.Api.Services;

public sealed class LoyaltyGrpcService : LoyaltyService.LoyaltyServiceBase
{
    private readonly ILoyaltyScoreService _service;
    private readonly LoyaltyGrpcMapper _mapper;
    private readonly IValidator<CalculateScoreRequest> _validator;

    public LoyaltyGrpcService(ILoyaltyScoreService service, LoyaltyGrpcMapper mapper, IValidator<CalculateScoreRequest> validator)
    {
        _service = service;
        _mapper = mapper;
        _validator = validator;
    }

    public override async Task<CalculateScoreResponse> CalculateScore(CalculateScoreGpcRequest request, ServerCallContext context)
    {
        var mapped = _mapper.Map(request);

        await _validator.ValidateAndThrowGrpc(mapped);

        var result = await _service.CalculateAsync(mapped, context.CancellationToken);

        return _mapper.Map(result.FinalScore);
    }
}
