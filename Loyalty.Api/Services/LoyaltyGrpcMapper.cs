
using Application.DTOs;
using Domain.Enums;

namespace Loyalty.Api.Services;

public sealed class LoyaltyGrpcMapper
{
    public CalculateScoreRequest Map(CalculateScoreGpcRequest request)
    {
        return new CalculateScoreRequest(
            (decimal)request.PurchaseAmount,
            (CustomerType)request.CustomerType,
            request.MonthlyPurchases?
                .Select(x => (decimal)x)
                .ToList()
        );
    }

    public CalculateScoreResponse Map(decimal score)
    {
        return new CalculateScoreResponse
        {
            FinalScore = (double)score
        };
    }
}
