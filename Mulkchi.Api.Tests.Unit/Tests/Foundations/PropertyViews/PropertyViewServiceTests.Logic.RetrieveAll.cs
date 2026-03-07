using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.PropertyViews;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.PropertyViews;

public partial class PropertyViewServiceTests
{
    [Fact]
    public void ShouldRetrieveAllPropertyViews()
    {
        // given
        IQueryable<PropertyView> randomPropertyViews = new List<PropertyView>
        {
            CreateRandomPropertyView(),
            CreateRandomPropertyView(),
            CreateRandomPropertyView()
        }.AsQueryable();

        IQueryable<PropertyView> expectedPropertyViews = randomPropertyViews;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllPropertyViews())
                .Returns(expectedPropertyViews);

        // when
        IQueryable<PropertyView> actualPropertyViews = this.propertyViewService.RetrieveAllPropertyViews();

        // then
        actualPropertyViews.Should().BeEquivalentTo(expectedPropertyViews);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllPropertyViews(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
