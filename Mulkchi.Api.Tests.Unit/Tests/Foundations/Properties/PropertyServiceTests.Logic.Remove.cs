using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Properties;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Properties;

public partial class PropertyServiceTests
{
    [Fact]
    public async Task ShouldRemovePropertyByIdAsync()
    {
        // given
        Property randomProperty = CreateRandomProperty();
        Property expectedProperty = randomProperty;

        this.storageBrokerMock.Setup(broker =>
            broker.DeletePropertyByIdAsync(randomProperty.Id))
                .ReturnsAsync(expectedProperty);

        // when
        Property actualProperty = await this.propertyService.RemovePropertyByIdAsync(randomProperty.Id);

        // then
        actualProperty.Should().BeEquivalentTo(expectedProperty);

        this.storageBrokerMock.Verify(broker =>
            broker.DeletePropertyByIdAsync(randomProperty.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
