using Mulkchi.Api.Models.Foundations.Payments;
using Mulkchi.Api.Models.Foundations.Payments.Exceptions;
using Xeptions;

namespace Mulkchi.Api.Services.Foundations.Payments;

public partial class PaymentService
{
    private void ValidatePaymentOnAdd(Payment payment)
    {
        ValidatePaymentIsNotNull(payment);
        Validate(
        (Rule: IsInvalid(payment.Id), Parameter: nameof(Payment.Id)));
    }

    private void ValidatePaymentOnModify(Payment payment)
    {
        ValidatePaymentIsNotNull(payment);
        Validate(
        (Rule: IsInvalid(payment.Id), Parameter: nameof(Payment.Id)));
    }

    private static void ValidatePaymentId(Guid paymentId)
    {
        if (paymentId == Guid.Empty)
        {
            throw new InvalidPaymentException(
                message: "Payment id is invalid.");
        }
    }

    private static void ValidatePaymentIsNotNull(Payment payment)
    {
        if (payment is null)
            throw new NullPaymentException(message: "Payment is null.");
    }

    private static dynamic IsInvalid(Guid id) => new
    {
        Condition = id == Guid.Empty,
        Message = "Id is required."
    };

    private static dynamic IsInvalid(string text) => new
    {
        Condition = string.IsNullOrWhiteSpace(text),
        Message = "Value is required."
    };

    private void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidPaymentException =
            new InvalidPaymentException(message: "Payment data is invalid.");

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
                invalidPaymentException.UpsertDataList(parameter, rule.Message);
        }

        invalidPaymentException.ThrowIfContainsErrors();
    }
}
