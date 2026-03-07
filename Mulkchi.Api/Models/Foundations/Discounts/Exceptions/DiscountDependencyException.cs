using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

public class DiscountDependencyException : Xeptions.Xeption
{
    public DiscountDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
