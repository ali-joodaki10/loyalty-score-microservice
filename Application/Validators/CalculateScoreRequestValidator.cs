using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CalculateScoreRequestValidator : AbstractValidator<CalculateScoreRequest>
{
    public CalculateScoreRequestValidator()
    {
        RuleFor(x => x.PurchaseAmount)
            .NotNull()
            .WithMessage("PurchaseAmount cannot be null")
            .GreaterThan(0)
            .WithMessage("PurchaseAmount must be greater than 0");

        RuleFor(x => x.CustomerType)
            .IsInEnum()
            .WithMessage("CustomerType is invalid");

        // MonthlyPurchases intentionally nullable → no validation here
    }
}