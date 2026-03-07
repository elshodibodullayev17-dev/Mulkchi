using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.SavedSearches;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.SavedSearches;

public partial class SavedSearchServiceTests
{
    [Fact]
    public async Task ShouldRemoveSavedSearchByIdAsync()
    {
        // given
        SavedSearch randomSavedSearch = CreateRandomSavedSearch();
        SavedSearch expectedSavedSearch = randomSavedSearch;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteSavedSearchByIdAsync(randomSavedSearch.Id))
                .ReturnsAsync(expectedSavedSearch);

        // when
        SavedSearch actualSavedSearch = await this.savedSearchService.RemoveSavedSearchByIdAsync(randomSavedSearch.Id);

        // then
        actualSavedSearch.Should().BeEquivalentTo(expectedSavedSearch);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteSavedSearchByIdAsync(randomSavedSearch.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
