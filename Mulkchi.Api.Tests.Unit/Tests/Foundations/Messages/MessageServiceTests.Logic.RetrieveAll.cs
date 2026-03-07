using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Messages;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Messages;

public partial class MessageServiceTests
{
    [Fact]
    public void ShouldRetrieveAllMessages()
    {
        // given
        IQueryable<Message> randomMessages = new List<Message>
        {
            CreateRandomMessage(),
            CreateRandomMessage(),
            CreateRandomMessage()
        }.AsQueryable();

        IQueryable<Message> expectedMessages = randomMessages;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllMessages())
                .Returns(expectedMessages);

        // when
        IQueryable<Message> actualMessages = this.messageService.RetrieveAllMessages();

        // then
        actualMessages.Should().BeEquivalentTo(expectedMessages);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllMessages(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
