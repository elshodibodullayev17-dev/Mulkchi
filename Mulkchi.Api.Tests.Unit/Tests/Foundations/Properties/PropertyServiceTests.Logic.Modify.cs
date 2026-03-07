using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Properties;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Properties;

public partial class PropertyServiceTests
{
    [Fact]
    public async Task ShouldModifyPropertyAsync()
    {
        // given
        Property randomProperty = CreateRandomProperty();
        Property inputProperty = randomProperty;
        Property expectedProperty = inputProperty;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdatePropertyAsync(inputProperty))
                .ReturnsAsync(expectedProperty);

        // when
        Property actualProperty = await this.propertyService.ModifyPropertyAsync(inputProperty);

        // then
        actualProperty.Should().BeEquivalentTo(expectedProperty);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdatePropertyAsync(inputProperty),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
