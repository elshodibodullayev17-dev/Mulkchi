using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Payments.Exceptions;

public class NullPaymentException : Xeptions.Xeption
{
    public NullPaymentException(string message)
        : base(message)
    { }
}
