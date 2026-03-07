using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class FailedPaymentServiceException : Xeptions.Xeption
{
    public FailedPaymentServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
