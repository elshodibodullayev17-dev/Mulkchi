using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

public class DiscountServiceException : Xeptions.Xeption
{
    public DiscountServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
