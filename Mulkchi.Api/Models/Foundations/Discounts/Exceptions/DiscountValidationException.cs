using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

public class DiscountValidationException : Xeptions.Xeption
{
    public DiscountValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
