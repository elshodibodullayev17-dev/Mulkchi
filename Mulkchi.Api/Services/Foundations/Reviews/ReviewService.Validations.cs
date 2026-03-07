using Mulkchi.Api.Models.Foundations.Reviews;
using Mulkchi.Api.Models.Foundations.Reviews.Exceptions;
using Xeptions;

namespace Mulkchi.Api.Services.Foundations.Reviews;

public partial class ReviewService
{
    private void ValidateReviewOnAdd(Review review)
    {
        ValidateReviewIsNotNull(review);
        Validate(
        (Rule: IsInvalid(review.Id), Parameter: nameof(Review.Id)),
        (Rule: IsInvalid(review.Comment), Parameter: nameof(Review.Comment)));
    }

    private void ValidateReviewOnModify(Review review)
    {
        ValidateReviewIsNotNull(review);
        Validate(
        (Rule: IsInvalid(review.Id), Parameter: nameof(Review.Id)),
        (Rule: IsInvalid(review.Comment), Parameter: nameof(Review.Comment)));
    }

    private static void ValidateReviewId(Guid reviewId)
    {
        if (reviewId == Guid.Empty)
        {
            throw new InvalidReviewException(
                message: "Review id is invalid.");
        }
    }

    private static void ValidateReviewIsNotNull(Review review)
    {
        if (review is null)
            throw new NullReviewException(message: "Review is null.");
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

    private void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidReviewException =
            new InvalidReviewException(message: "Review data is invalid.");

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
                invalidReviewException.UpsertDataList(parameter, rule.Message);
        }

        invalidReviewException.ThrowIfContainsErrors();
    }
}
