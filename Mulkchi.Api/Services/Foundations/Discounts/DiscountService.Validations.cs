using Mulkchi.Api.Models.Foundations.Discounts;
using Mulkchi.Api.Models.Foundations.Discounts.Exceptions;
using Xeptions;

namespace Mulkchi.Api.Services.Foundations.Discounts;

public partial class DiscountService
{
    private void ValidateDiscountOnAdd(Discount discount)
    {
        ValidateDiscountIsNotNull(discount);
        Validate(
        (Rule: IsInvalid(discount.Id), Parameter: nameof(Discount.Id)),
        (Rule: IsInvalid(discount.Code), Parameter: nameof(Discount.Code)),
        (Rule: IsInvalidOrNegative(discount.Value), Parameter: nameof(Discount.Value)),
        (Rule: IsExpired(discount.ExpiresAt), Parameter: nameof(Discount.ExpiresAt)));
    }

    private void ValidateDiscountOnModify(Discount discount)
    {
        ValidateDiscountIsNotNull(discount);
        Validate(
        (Rule: IsInvalid(discount.Id), Parameter: nameof(Discount.Id)),
        (Rule: IsInvalid(discount.Code), Parameter: nameof(Discount.Code)),
        (Rule: IsInvalidOrNegative(discount.Value), Parameter: nameof(Discount.Value)),
        (Rule: IsExpired(discount.ExpiresAt), Parameter: nameof(Discount.ExpiresAt)));
    }

    private static void ValidateDiscountId(Guid discountId)
    {
        if (discountId == Guid.Empty)
        {
            throw new InvalidDiscountException(
                message: "Discount id is invalid.");
        }
    }

    private static void ValidateDiscountIsNotNull(Discount discount)
    {
        if (discount is null)
            throw new NullDiscountException(message: "Discount is null.");
    }

    private static dynamic IsInvalid(Guid id) => new
    {
        Condition = id == Guid.Empty,
        Message = "Id is required."
    };

    private static dynamic IsInvalid(string text) => new
    {
        Condition = string.IsNullOrWhiteSpace(text),
        Message = "Value is required."
    };

    private static dynamic IsInvalidOrNegative(decimal value) => new
    {
        Condition = value <= 0,
        Message = "Value must be greater than zero."
    };

    private static dynamic IsExpired(DateTimeOffset? expiresAt) => new
    {
        Condition = expiresAt.HasValue && expiresAt.Value <= DateTimeOffset.UtcNow,
        Message = "Expiry date must be in the future."
    };

    private void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidDiscountException =
            new InvalidDiscountException(message: "Discount data is invalid.");

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
                invalidDiscountException.UpsertDataList(parameter, rule.Message);
        }

        invalidDiscountException.ThrowIfContainsErrors();
    }
}
