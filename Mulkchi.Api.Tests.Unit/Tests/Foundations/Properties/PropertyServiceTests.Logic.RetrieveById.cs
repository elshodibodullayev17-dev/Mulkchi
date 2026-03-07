using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Properties;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Properties;

public partial class PropertyServiceTests
{
    [Fact]
    public async Task ShouldRetrievePropertyByIdAsync()
    {
        // given
        Property randomProperty = CreateRandomProperty();
        Property expectedProperty = randomProperty;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectPropertyByIdAsync(randomProperty.Id))
                .ReturnsAsync(expectedProperty);

        // when
        Property actualProperty = await this.propertyService.RetrievePropertyByIdAsync(randomProperty.Id);

        // then
        actualProperty.Should().BeEquivalentTo(expectedProperty);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectPropertyByIdAsync(randomProperty.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
