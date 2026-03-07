using Xeptions;

namespace Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

public class RentalContractDependencyException : Xeptions.Xeption
{
    public RentalContractDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
