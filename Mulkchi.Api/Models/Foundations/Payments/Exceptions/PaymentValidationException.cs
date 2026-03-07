using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class PaymentValidationException : Xeptions.Xeption
{
    public PaymentValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
