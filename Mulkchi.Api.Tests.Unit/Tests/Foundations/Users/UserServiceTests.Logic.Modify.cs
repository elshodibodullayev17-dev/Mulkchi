using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldModifyUserAsync()
    {
        // given
        User randomUser = CreateRandomUser();
        User inputUser = randomUser;
        User expectedUser = inputUser;

        this.storageBrokerMock.Setup(broker =>
            broker.UpdateUserAsync(inputUser))
                .ReturnsAsync(expectedUser);

        // when
        User actualUser = await this.userService.ModifyUserAsync(inputUser);

        // then
        actualUser.Should().BeEquivalentTo(expectedUser);

        this.storageBrokerMock.Verify(broker =>
            broker.UpdateUserAsync(inputUser),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
