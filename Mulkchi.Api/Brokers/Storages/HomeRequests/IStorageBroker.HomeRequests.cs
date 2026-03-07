using Mulkchi.Api.Models.Foundations.HomeRequests;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<HomeRequest> InsertHomeRequestAsync(HomeRequest homeRequest);
    IQueryable<HomeRequest> SelectAllHomeRequests();
    ValueTask<HomeRequest> SelectHomeRequestByIdAsync(Guid homeRequestId);
    ValueTask<HomeRequest> UpdateHomeRequestAsync(HomeRequest homeRequest);
    ValueTask<HomeRequest> DeleteHomeRequestByIdAsync(Guid homeRequestId);
}
