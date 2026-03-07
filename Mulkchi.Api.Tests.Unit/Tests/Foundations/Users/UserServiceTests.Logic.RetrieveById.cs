using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldRetrieveUserByIdAsync()
    {
        // given
        User randomUser = CreateRandomUser();
        User expectedUser = randomUser;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectUserByIdAsync(randomUser.Id))
                .ReturnsAsync(expectedUser);

        // when
        User actualUser = await this.userService.RetrieveUserByIdAsync(randomUser.Id);

        // then
        actualUser.Should().BeEquivalentTo(expectedUser);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectUserByIdAsync(randomUser.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
