using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class PaymentDependencyException : Xeptions.Xeption
{
    public PaymentDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
