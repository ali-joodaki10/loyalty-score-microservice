using Application.DTOs;

namespace Application.Interfaces;

public interface ILoyaltyScoreService
{
    Task<CalculateScoreResponse> CalculateAsync(CalculateScoreRequest request, CancellationToken cancellationToken);
}
