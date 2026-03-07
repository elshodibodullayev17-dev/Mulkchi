using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Messages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Messages;

public partial class MessageServiceTests
{
    [Fact]
    public async Task ShouldRemoveMessageByIdAsync()
    {
        // given
        Message randomMessage = CreateRandomMessage();
        Message expectedMessage = randomMessage;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteMessageByIdAsync(randomMessage.Id))
                .ReturnsAsync(expectedMessage);

        // when
        Message actualMessage = await this.messageService.RemoveMessageByIdAsync(randomMessage.Id);

        // then
        actualMessage.Should().BeEquivalentTo(expectedMessage);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteMessageByIdAsync(randomMessage.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
