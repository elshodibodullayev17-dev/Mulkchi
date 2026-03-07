using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.SavedSearches;
using Mulkchi.Api.Models.Foundations.SavedSearches.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.SavedSearches;

public partial class SavedSearchServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        SavedSearch someSavedSearch = CreateRandomSavedSearch();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertSavedSearchAsync(It.IsAny<SavedSearch>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addSavedSearchTask = async () =>
            await this.savedSearchService.AddSavedSearchAsync(someSavedSearch);

        // then
        SavedSearchDependencyException actualException =
            await Assert.ThrowsAsync<SavedSearchDependencyException>(
                testCode: async () => await addSavedSearchTask());

        actualException.InnerException.Should().BeOfType<FailedSavedSearchStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertSavedSearchAsync(It.IsAny<SavedSearch>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        SavedSearch someSavedSearch = CreateRandomSavedSearch();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertSavedSearchAsync(It.IsAny<SavedSearch>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addSavedSearchTask = async () =>
            await this.savedSearchService.AddSavedSearchAsync(someSavedSearch);

        // then
        SavedSearchServiceException actualException =
            await Assert.ThrowsAsync<SavedSearchServiceException>(
                testCode: async () => await addSavedSearchTask());

        actualException.InnerException.Should().BeOfType<FailedSavedSearchServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertSavedSearchAsync(It.IsAny<SavedSearch>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
