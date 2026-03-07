using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Mulkchi.Api.Models.Foundations.Messages;
using Mulkchi.Api.Models.Foundations.Messages.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Messages;

public partial class MessageServiceTests
{
    [Fact]
    public async Task ShouldThrowDependencyException_OnAdd_WhenSqlExceptionOccurs()
    {
        // given
        Message someMessage = CreateRandomMessage();
        SqlException sqlException = CreateSqlException();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertMessageAsync(It.IsAny<Message>()))
                .ThrowsAsync(sqlException);

        // when
        Func<Task> addMessageTask = async () =>
            await this.messageService.AddMessageAsync(someMessage);

        // then
        MessageDependencyException actualException =
            await Assert.ThrowsAsync<MessageDependencyException>(
                testCode: async () => await addMessageTask());

        actualException.InnerException.Should().BeOfType<FailedMessageStorageException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertMessageAsync(It.IsAny<Message>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowServiceException_OnAdd_WhenExceptionOccurs()
    {
        // given
        Message someMessage = CreateRandomMessage();
        var exception = new Exception();

        this.storageBrokerMock.Setup(broker =>
            broker.InsertMessageAsync(It.IsAny<Message>()))
                .ThrowsAsync(exception);

        // when
        Func<Task> addMessageTask = async () =>
            await this.messageService.AddMessageAsync(someMessage);

        // then
        MessageServiceException actualException =
            await Assert.ThrowsAsync<MessageServiceException>(
                testCode: async () => await addMessageTask());

        actualException.InnerException.Should().BeOfType<FailedMessageServiceException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertMessageAsync(It.IsAny<Message>()),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
