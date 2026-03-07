using Mulkchi.Api.Models.Foundations.Reviews;
using Mulkchi.Api.Models.Foundations.Reviews.Exceptions;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.Reviews;

public partial class ReviewService : IReviewService
{
    private readonly IStorageBroker storageBroker;

    public ReviewService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public ValueTask<Review> AddReviewAsync(Review review) =>
        TryCatch(async () =>
        {
            ValidateReviewOnAdd(review);
            return await this.storageBroker.InsertReviewAsync(review);
        });

    public IQueryable<Review> RetrieveAllReviews() =>
        TryCatch(() => this.storageBroker.SelectAllReviews());

    public ValueTask<Review> RetrieveReviewByIdAsync(Guid reviewId) =>
        TryCatch(async () =>
        {
            ValidateReviewId(reviewId);
            Review maybeReview = await this.storageBroker.SelectReviewByIdAsync(reviewId);

            if (maybeReview is null)
                throw new NotFoundReviewException(reviewId);

            return maybeReview;
        });

    public ValueTask<Review> ModifyReviewAsync(Review review) =>
        TryCatch(async () =>
        {
            ValidateReviewOnModify(review);
            return await this.storageBroker.UpdateReviewAsync(review);
        });

    public ValueTask<Review> RemoveReviewByIdAsync(Guid reviewId) =>
        TryCatch(async () =>
        {
            ValidateReviewId(reviewId);
            return await this.storageBroker.DeleteReviewByIdAsync(reviewId);
        });
}
