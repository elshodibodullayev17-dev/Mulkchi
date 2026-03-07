using Microsoft.EntityFrameworkCore;

namespace Mulkchi.Api.Brokers.Storages;

public partial class StorageBroker : DbContext, IStorageBroker
{
    private readonly IConfiguration configuration;

    public StorageBroker(
        DbContextOptions<StorageBroker> options,
        IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
        this.Database.EnsureCreated();
    }
}
