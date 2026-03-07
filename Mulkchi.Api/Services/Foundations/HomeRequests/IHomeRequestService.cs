using Mulkchi.Api.Models.Foundations.HomeRequests;

namespace Mulkchi.Api.Services.Foundations.HomeRequests;

public interface IHomeRequestService
{
    ValueTask<HomeRequest> AddHomeRequestAsync(HomeRequest homeRequest);
    IQueryable<HomeRequest> RetrieveAllHomeRequests();
    ValueTask<HomeRequest> RetrieveHomeRequestByIdAsync(Guid homeRequestId);
    ValueTask<HomeRequest> ModifyHomeRequestAsync(HomeRequest homeRequest);
    ValueTask<HomeRequest> RemoveHomeRequestByIdAsync(Guid homeRequestId);
}
