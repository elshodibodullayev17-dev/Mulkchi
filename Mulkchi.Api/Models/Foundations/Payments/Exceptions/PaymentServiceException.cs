using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class PaymentServiceException : Xeptions.Xeption
{
    public PaymentServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
