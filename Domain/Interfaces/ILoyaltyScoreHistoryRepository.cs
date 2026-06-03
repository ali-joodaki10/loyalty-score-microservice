using Domain.Entities;

namespace Domain.Interfaces;

public interface ILoyaltyScoreHistoryRepository
{
    Task AddAsync(LoyaltyScoreHistory history, CancellationToken cancellationToken);
}