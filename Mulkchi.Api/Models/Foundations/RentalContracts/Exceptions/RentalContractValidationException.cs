using Xeptions;

namespace Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

public class RentalContractValidationException : Xeptions.Xeption
{
    public RentalContractValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
