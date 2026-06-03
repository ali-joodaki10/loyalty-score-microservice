using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class LoyaltyScoreHistoryRepository : ILoyaltyScoreHistoryRepository
{
    private readonly AppDbContext _db;

    public LoyaltyScoreHistoryRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(LoyaltyScoreHistory history, CancellationToken cancellationToken)
    {
        await _db.LoyaltyScoreHistories.AddAsync(history, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }
}