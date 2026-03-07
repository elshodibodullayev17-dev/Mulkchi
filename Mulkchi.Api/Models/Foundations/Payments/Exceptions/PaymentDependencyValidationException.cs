using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class PaymentDependencyValidationException : Xeptions.Xeption
{
    public PaymentDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
