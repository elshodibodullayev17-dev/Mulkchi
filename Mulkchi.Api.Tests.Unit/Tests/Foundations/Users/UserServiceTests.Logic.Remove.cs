using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldRemoveUserByIdAsync()
    {
        // given
        User randomUser = CreateRandomUser();
        User expectedUser = randomUser;

        this.storageBrokerMock.Setup(broker =>
            broker.DeleteUserByIdAsync(randomUser.Id))
                .ReturnsAsync(expectedUser);

        // when
        User actualUser = await this.userService.RemoveUserByIdAsync(randomUser.Id);

        // then
        actualUser.Should().BeEquivalentTo(expectedUser);

        this.storageBrokerMock.Verify(broker =>
            broker.DeleteUserByIdAsync(randomUser.Id),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
