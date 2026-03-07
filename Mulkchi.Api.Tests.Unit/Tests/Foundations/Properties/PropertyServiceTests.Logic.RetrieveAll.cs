using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Properties;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Properties;

public partial class PropertyServiceTests
{
    [Fact]
    public void ShouldRetrieveAllProperties()
    {
        // given
        IQueryable<Property> randomProperties = new List<Property>
        {
            CreateRandomProperty(),
            CreateRandomProperty(),
            CreateRandomProperty()
        }.AsQueryable();

        IQueryable<Property> expectedProperties = randomProperties;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllProperties())
                .Returns(expectedProperties);

        // when
        IQueryable<Property> actualProperties = this.propertyService.RetrieveAllProperties();

        // then
        actualProperties.Should().BeEquivalentTo(expectedProperties);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllProperties(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
