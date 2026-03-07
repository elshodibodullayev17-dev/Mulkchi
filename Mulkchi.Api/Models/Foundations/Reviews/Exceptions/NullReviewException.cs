using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class NullReviewException : Xeptions.Xeption
{
    public NullReviewException(string message)
        : base(message)
    { }
}
