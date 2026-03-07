using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

public class DiscountDependencyValidationException : Xeptions.Xeption
{
    public DiscountDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
