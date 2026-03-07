using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Messages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Messages;

public partial class MessageServiceTests
{
    [Fact]
    public async Task ShouldModifyMessageAsync()
    {
        // given
        Message randomMessage = CreateRandomMessage();
        Message inputMessage = randomMessage;
        Message expectedMessage = inputMessage;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateMessageAsync(inputMessage))
                .ReturnsAsync(expectedMessage);

        // when
        Message actualMessage = await this.messageService.ModifyMessageAsync(inputMessage);

        // then
        actualMessage.Should().BeEquivalentTo(expectedMessage);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateMessageAsync(inputMessage),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
