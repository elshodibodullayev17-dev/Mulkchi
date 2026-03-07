using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldAddUserAsync()
    {
        // given
        User randomUser = CreateRandomUser();
        User inputUser = randomUser;
        User expectedUser = inputUser;

        this.storageBrokerMock.Setup(broker =>
            broker.InsertUserAsync(inputUser))
                .ReturnsAsync(expectedUser);

        // when
        User actualUser = await this.userService.AddUserAsync(inputUser);

        // then
        actualUser.Should().BeEquivalentTo(expectedUser);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertUserAsync(inputUser),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
