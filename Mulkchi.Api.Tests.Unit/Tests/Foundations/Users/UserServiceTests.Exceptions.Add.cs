using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;
using Mulkchi.Api.Models.Foundations.Users.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        User someUser = CreateRandomUser();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertUserAsync(It.IsAny<User>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addUserTask = async () =>
            await this.userService.AddUserAsync(someUser);

        // then
        UserDependencyException actualException =
            await Assert.ThrowsAsync<UserDependencyException>(
                testCode: async () => await addUserTask());

        actualException.InnerException.Should().BeOfType<FailedUserStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertUserAsync(It.IsAny<User>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        User someUser = CreateRandomUser();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertUserAsync(It.IsAny<User>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addUserTask = async () =>
            await this.userService.AddUserAsync(someUser);

        // then
        UserServiceException actualException =
            await Assert.ThrowsAsync<UserServiceException>(
                testCode: async () => await addUserTask());

        actualException.InnerException.Should().BeOfType<FailedUserServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertUserAsync(It.IsAny<User>()),
            Times.Once);

        this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.IsAny<Exception>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}
