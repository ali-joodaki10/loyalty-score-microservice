using Domain.Enums;

namespace Application.DTOs;

public sealed record CalculateScoreRequest(
    decimal PurchaseAmount,
    CustomerType CustomerType,
    List<decimal>? MonthlyPurchases = null
);

//public sealed record CalculateScoreRequest
//{
//    public decimal PurchaseAmount { get; set; }
//    public CustomerType CustomerType { get; set; }
//    public List<decimal>? MonthlyPurchases { get; set; } = null
//}
