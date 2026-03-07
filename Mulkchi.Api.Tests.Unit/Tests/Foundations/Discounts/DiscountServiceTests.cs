using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Mulkchi.Api.Brokers.Storages;
using Mulkchi.Api.Models.Foundations.Discounts;
using Mulkchi.Api.Services.Foundations.Discounts;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Discounts;

public partial class DiscountServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly IDiscountService discountService;

    public DiscountServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.discountService = new DiscountService(this.storageBrokerMock.Object);
    }

    private static Discount CreateRandomDiscount()
    {
        var filler = new Filler<Discount>();
        filler.Setup()
            .OnType<DateTimeOffset>().Use(() => DateTimeOffset.UtcNow)
            .OnType<DateTimeOffset?>().Use(() => (DateTimeOffset?)DateTimeOffset.UtcNow);

        return filler.Create();
    }

    private static SqlException CreateSqlException() =>
        (SqlException)RuntimeHelpers.GetUninitializedObject(typeof(SqlException));
}
