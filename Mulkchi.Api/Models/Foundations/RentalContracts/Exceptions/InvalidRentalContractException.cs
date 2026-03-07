using Xeptions;

namespace Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

public class InvalidRentalContractException : Xeptions.Xeption
{
    public InvalidRentalContractException(string message)
        : base(message)
    { }

    public InvalidRentalContractException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
