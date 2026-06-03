using Domain.Enums;

namespace Domain.Entities;

public class LoyaltyScoreHistory
{
    public Guid Id { get; private set; }

    public decimal PurchaseAmount { get; private set; }

    public CustomerType CustomerType { get; private set; }

    public string MonthlyPurchasesJson { get; private set; }

    public decimal FinalScore { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private LoyaltyScoreHistory() { }

    public LoyaltyScoreHistory(
        decimal purchaseAmount,
        CustomerType customerType,
        string monthlyPurchasesJson,
        decimal finalScore)
    {
        Id = Guid.NewGuid();
        PurchaseAmount = purchaseAmount;
        CustomerType = customerType;
        MonthlyPurchasesJson = monthlyPurchasesJson;
        FinalScore = finalScore;
        CreatedAt = DateTime.UtcNow;
    }
}
