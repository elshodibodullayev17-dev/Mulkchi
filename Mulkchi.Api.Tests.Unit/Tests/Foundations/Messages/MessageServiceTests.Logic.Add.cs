using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Messages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Messages;

public partial class MessageServiceTests
{
    [Fact]
    public async Task ShouldAddMessageAsync()
    {
        // given
        Message randomMessage = CreateRandomMessage();
        Message inputMessage = randomMessage;
        Message expectedMessage = inputMessage;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertMessageAsync(inputMessage))
                .ReturnsAsync(expectedMessage);

        // when
        Message actualMessage = await this.messageService.AddMessageAsync(inputMessage);

        // then
        actualMessage.Should().BeEquivalentTo(expectedMessage);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertMessageAsync(inputMessage),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
