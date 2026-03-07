using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.SavedSearches;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.SavedSearches;

public partial class SavedSearchServiceTests
{
    [Fact]
    public async Task ShouldAddSavedSearchAsync()
    {
        // given
        SavedSearch randomSavedSearch = CreateRandomSavedSearch();
        SavedSearch inputSavedSearch = randomSavedSearch;
        SavedSearch expectedSavedSearch = inputSavedSearch;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertSavedSearchAsync(inputSavedSearch))
                .ReturnsAsync(expectedSavedSearch);

        // when
        SavedSearch actualSavedSearch = await this.savedSearchService.AddSavedSearchAsync(inputSavedSearch);

        // then
        actualSavedSearch.Should().BeEquivalentTo(expectedSavedSearch);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertSavedSearchAsync(inputSavedSearch),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
