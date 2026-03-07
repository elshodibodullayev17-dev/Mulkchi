using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Discounts.Exceptions;

public class NullDiscountException : Xeptions.Xeption
{
    public NullDiscountException(string message)
        : base(message)
    { }
}
