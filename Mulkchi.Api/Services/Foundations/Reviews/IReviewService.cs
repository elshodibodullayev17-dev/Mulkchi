using Mulkchi.Api.Models.Foundations.Reviews;

namespace Mulkchi.Api.Services.Foundations.Reviews;

public interface IReviewService
{
    ValueTask<Review> AddReviewAsync(Review review);
    IQueryable<Review> RetrieveAllReviews();
    ValueTask<Review> RetrieveReviewByIdAsync(Guid reviewId);
    ValueTask<Review> ModifyReviewAsync(Review review);
    ValueTask<Review> RemoveReviewByIdAsync(Guid reviewId);
}
