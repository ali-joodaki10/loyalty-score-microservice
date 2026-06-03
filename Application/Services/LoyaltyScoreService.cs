using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Domain.Interfaces;
using Domain.Services;

namespace Application.Services;

public sealed class LoyaltyScoreService : ILoyaltyScoreService
{
    private readonly ILoyaltyScoreCalculator _calculator;
    private readonly ILoyaltyScoreHistoryRepository _repo;
    private readonly LoyaltyScoreMapper _mapper;

    public LoyaltyScoreService(
        ILoyaltyScoreCalculator calculator,
        ILoyaltyScoreHistoryRepository repo,
        LoyaltyScoreMapper mapper)
    {
        _calculator = calculator;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<CalculateScoreResponse> CalculateAsync(CalculateScoreRequest request, CancellationToken cancellationToken)
    {
        var score = _calculator.Calculate(request.PurchaseAmount, request.CustomerType, request.MonthlyPurchases ?? []);

        var loyaltyScoreHistory = _mapper.Map(request, score);

        await _repo.AddAsync(loyaltyScoreHistory, cancellationToken);

        return _mapper.Map(score);

    }
}
