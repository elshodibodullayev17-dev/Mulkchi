using Xeptions;

namespace Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

public class RentalContractServiceException : Xeptions.Xeption
{
    public RentalContractServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
