using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Properties;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Properties;

public partial class PropertyServiceTests
{
    [Fact]
    public async Task ShouldAddPropertyAsync()
    {
        // given
        Property randomProperty = CreateRandomProperty();
        Property inputProperty = randomProperty;
        Property expectedProperty = inputProperty;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertPropertyAsync(inputProperty))
                .ReturnsAsync(expectedProperty);

        // when
        Property actualProperty = await this.propertyService.AddPropertyAsync(inputProperty);

        // then
        actualProperty.Should().BeEquivalentTo(expectedProperty);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertPropertyAsync(inputProperty),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
