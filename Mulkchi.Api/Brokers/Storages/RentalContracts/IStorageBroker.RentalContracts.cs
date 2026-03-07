using Mulkchi.Api.Models.Foundations.RentalContracts;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<RentalContract> InsertRentalContractAsync(RentalContract rentalContract);
    IQueryable<RentalContract> SelectAllRentalContracts();
    ValueTask<RentalContract> SelectRentalContractByIdAsync(Guid rentalContractId);
    ValueTask<RentalContract> UpdateRentalContractAsync(RentalContract rentalContract);
    ValueTask<RentalContract> DeleteRentalContractByIdAsync(Guid rentalContractId);
}
