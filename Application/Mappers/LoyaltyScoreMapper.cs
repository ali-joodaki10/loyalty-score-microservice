using Application.DTOs;
using Domain.Entities;
using static System.Formats.Asn1.AsnWriter;

namespace Application.Mappers;

public sealed class LoyaltyScoreMapper
{
    public LoyaltyScoreHistory Map(CalculateScoreRequest request, decimal finalScore)
    {
        var monthlyPurchasesRaw = (request.MonthlyPurchases != null && request.MonthlyPurchases.Any())
            ? string.Join(",", request.MonthlyPurchases)
            : "";

        return new LoyaltyScoreHistory(request.PurchaseAmount, request.CustomerType, monthlyPurchasesRaw, finalScore);
    }

    public CalculateScoreResponse Map(decimal score)
    {
        return new CalculateScoreResponse
        {
            FinalScore = score
        };
    }
}
