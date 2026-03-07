using Mulkchi.Api.Models.Foundations.HomeRequests;
using Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.HomeRequests;

public partial class HomeRequestService : IHomeRequestService
{
    private readonly IStorageBroker storageBroker;

    public HomeRequestService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public ValueTask<HomeRequest> AddHomeRequestAsync(HomeRequest homeRequest) =>
        TryCatch(async () =>
        {
            ValidateHomeRequestOnAdd(homeRequest);
            return await this.storageBroker.InsertHomeRequestAsync(homeRequest);
        });

    public IQueryable<HomeRequest> RetrieveAllHomeRequests() =>
        TryCatch(() => this.storageBroker.SelectAllHomeRequests());

    public ValueTask<HomeRequest> RetrieveHomeRequestByIdAsync(Guid homeRequestId) =>
        TryCatch(async () =>
        {
            ValidateHomeRequestId(homeRequestId);
            HomeRequest maybeHomeRequest = await this.storageBroker.SelectHomeRequestByIdAsync(homeRequestId);

            if (maybeHomeRequest is null)
                throw new NotFoundHomeRequestException(homeRequestId);

            return maybeHomeRequest;
        });

    public ValueTask<HomeRequest> ModifyHomeRequestAsync(HomeRequest homeRequest) =>
        TryCatch(async () =>
        {
            ValidateHomeRequestOnModify(homeRequest);
            return await this.storageBroker.UpdateHomeRequestAsync(homeRequest);
        });

    public ValueTask<HomeRequest> RemoveHomeRequestByIdAsync(Guid homeRequestId) =>
        TryCatch(async () =>
        {
            ValidateHomeRequestId(homeRequestId);
            return await this.storageBroker.DeleteHomeRequestByIdAsync(homeRequestId);
        });
}
