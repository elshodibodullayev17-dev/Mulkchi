using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.SavedSearches;
using Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.SavedSearches;

public partial class SavedSearchServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullSavedSearch()
    {
        // given
        SavedSearch? inputSavedSearch = null;

        // when
        ValueTask<SavedSearch> addSavedSearchTask =
            this.savedSearchService.AddSavedSearchAsync(inputSavedSearch!);

        // then
        SavedSearchValidationException actualException =
            await Assert.ThrowsAsync<SavedSearchValidationException>(
                testCode: async () => await addSavedSearchTask);

        actualException.InnerException.Should().BeOfType<NullSavedSearchException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertSavedSearchAsync(It.IsAny<SavedSearch>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        SavedSearch randomSavedSearch = CreateRandomSavedSearch();
        randomSavedSearch.Id = Guid.Empty;

        // when
        ValueTask<SavedSearch> addSavedSearchTask =
            this.savedSearchService.AddSavedSearchAsync(randomSavedSearch);

        // then
        await Assert.ThrowsAsync<SavedSearchValidationException>(
            testCode: async () => await addSavedSearchTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertSavedSearchAsync(It.IsAny<SavedSearch>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
