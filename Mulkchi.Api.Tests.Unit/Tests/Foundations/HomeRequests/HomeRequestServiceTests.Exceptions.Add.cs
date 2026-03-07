using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.HomeRequests;
using Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.HomeRequests;

public partial class HomeRequestServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        HomeRequest someHomeRequest = CreateRandomHomeRequest();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertHomeRequestAsync(It.IsAny<HomeRequest>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addHomeRequestTask = async () =>
            await this.homeRequestService.AddHomeRequestAsync(someHomeRequest);

        // then
        HomeRequestDependencyException actualException =
            await Assert.ThrowsAsync<HomeRequestDependencyException>(
                testCode: async () => await addHomeRequestTask());

        actualException.InnerException.Should().BeOfType<FailedHomeRequestStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertHomeRequestAsync(It.IsAny<HomeRequest>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        HomeRequest someHomeRequest = CreateRandomHomeRequest();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertHomeRequestAsync(It.IsAny<HomeRequest>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addHomeRequestTask = async () =>
            await this.homeRequestService.AddHomeRequestAsync(someHomeRequest);

        // then
        HomeRequestServiceException actualException =
            await Assert.ThrowsAsync<HomeRequestServiceException>(
                testCode: async () => await addHomeRequestTask());

        actualException.InnerException.Should().BeOfType<FailedHomeRequestServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertHomeRequestAsync(It.IsAny<HomeRequest>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
