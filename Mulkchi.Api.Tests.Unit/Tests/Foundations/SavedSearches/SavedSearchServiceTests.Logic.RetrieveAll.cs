using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.SavedSearches;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.SavedSearches;

public partial class SavedSearchServiceTests
{
    [Fact]
    public void ShouldRetrieveAllSavedSearches()
    {
        // given
        IQueryable<SavedSearch> randomSavedSearches = new List<SavedSearch>
        {
            CreateRandomSavedSearch(),
            CreateRandomSavedSearch(),
            CreateRandomSavedSearch()
        }.AsQueryable();

        IQueryable<SavedSearch> expectedSavedSearches = randomSavedSearches;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllSavedSearches())
                .Returns(expectedSavedSearches);

        // when
        IQueryable<SavedSearch> actualSavedSearches = this.savedSearchService.RetrieveAllSavedSearches();

        // then
        actualSavedSearches.Should().BeEquivalentTo(expectedSavedSearches);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllSavedSearches(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
