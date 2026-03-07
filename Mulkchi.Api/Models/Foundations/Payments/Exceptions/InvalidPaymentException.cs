using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class InvalidPaymentException : Xeptions.Xeption
{
    public InvalidPaymentException(string message)
        : base(message)
    { }

    public InvalidPaymentException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
