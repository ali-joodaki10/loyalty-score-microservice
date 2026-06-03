using Domain.Enums;

namespace Domain.Services;

public interface ILoyaltyScoreCalculator
{
    decimal Calculate(decimal purchaseAmount, CustomerType customerType, IReadOnlyCollection<decimal> monthlyPurchases);
}
