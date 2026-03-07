using Xeptions;

namespace Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

public class RentalContractDependencyValidationException : Xeptions.Xeption
{
    public RentalContractDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
