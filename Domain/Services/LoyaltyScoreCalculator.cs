using Domain.Enums;

namespace Domain.Services;

public class LoyaltyScoreCalculator : ILoyaltyScoreCalculator
{
    public decimal Calculate(
        decimal purchaseAmount,
        CustomerType customerType,
        IReadOnlyCollection<decimal> monthlyPurchases)
    {
        var baseScore = CalculateBaseScore(purchaseAmount, customerType);

        var bonus = CalculateBonus(purchaseAmount, monthlyPurchases);

        return baseScore * (1 + bonus);
    }

    // ---------------- Base Score ----------------
    private decimal CalculateBaseScore(
        decimal purchaseAmount,
        CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Bronze => purchaseAmount / 100m,
            CustomerType.Silver => purchaseAmount / 80m,
            CustomerType.Gold => purchaseAmount / 60m,
            _ => throw new ArgumentOutOfRangeException(nameof(customerType))
        };
    }

    // ---------------- Bonus Aggregator ----------------
    private decimal CalculateBonus(
        decimal purchaseAmount,
        IReadOnlyCollection<decimal> monthlyPurchases)
    {
        decimal bonus = 0;

        bonus += CalculateFrequencyBonus(monthlyPurchases);
        bonus += CalculateAmountBonus(purchaseAmount);

        return bonus;
    }

    // ---------------- Frequency Bonus ----------------
    private decimal CalculateFrequencyBonus(
        IReadOnlyCollection<decimal> monthlyPurchases)
    {
        if (monthlyPurchases != null && monthlyPurchases.Count >= 5)
            return 0.10m;

        return 0m;
    }

    // ---------------- Amount Bonus ----------------
    private decimal CalculateAmountBonus(decimal purchaseAmount)
    {
        decimal bonus = 0m;

        if (purchaseAmount > 10_000_000m)
        {
            bonus += 0.05m;

            var steps =
                (int)((purchaseAmount - 10_000_000m) / 10_000_000m);

            bonus += steps * 0.025m;
        }

        return bonus;
    }
}