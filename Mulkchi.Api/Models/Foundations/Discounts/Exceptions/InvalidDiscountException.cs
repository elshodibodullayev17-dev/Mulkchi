using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

public class InvalidDiscountException : Xeptions.Xeption
{
    public InvalidDiscountException(string message)
        : base(message)
    { }

    public InvalidDiscountException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
