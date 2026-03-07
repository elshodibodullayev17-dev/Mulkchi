using Xeptions;

namespace Mulkchi.Api.Models.Foundations.RentalContracts.Exceptions;

public class AlreadyExistsRentalContractException : Xeptions.Xeption
{
    public AlreadyExistsRentalContractException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
