using Mulkchi.Api.Models.Foundations.RentalContracts;

namespace Mulkchi.Api.Services.Foundations.RentalContracts;

public interface IRentalContractService
{
    ValueTask<RentalContract> AddRentalContractAsync(RentalContract rentalContract);
    IQueryable<RentalContract> RetrieveAllRentalContracts();
    ValueTask<RentalContract> RetrieveRentalContractByIdAsync(Guid rentalContractId);
    ValueTask<RentalContract> ModifyRentalContractAsync(RentalContract rentalContract);
    ValueTask<RentalContract> RemoveRentalContractByIdAsync(Guid rentalContractId);
}
