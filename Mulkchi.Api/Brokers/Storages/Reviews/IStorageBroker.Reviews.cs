using Mulkchi.Api.Models.Foundations.Reviews;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Review> InsertReviewAsync(Review review);
    IQueryable<Review> SelectAllReviews();
    ValueTask<Review> SelectReviewByIdAsync(Guid reviewId);
    ValueTask<Review> UpdateReviewAsync(Review review);
    ValueTask<Review> DeleteReviewByIdAsync(Guid reviewId);
}
