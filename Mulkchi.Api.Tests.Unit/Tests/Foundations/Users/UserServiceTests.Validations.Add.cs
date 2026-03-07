using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;
using Mulkchi.Api.Models.Foundations.Users.Exceptions;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenNullUser()
    {
        // given
        User? inputUser = null;

        // when
        ValueTask<User> addUserTask =
            this.userService.AddUserAsync(inputUser!);

        // then
        UserValidationException actualException =
            await Assert.ThrowsAsync<UserValidationException>(
                testCode: async () => await addUserTask);

        actualException.InnerException.Should().BeOfType<NullUserException>();

        this.storageBrokerMock.Verify(broker =>
            broker.InsertUserAsync(It.IsAny<User>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAdd_WhenIdIsEmpty()
    {
        // given
        User randomUser = CreateRandomUser();
        randomUser.Id = Guid.Empty;

        // when
        ValueTask<User> addUserTask =
            this.userService.AddUserAsync(randomUser);

        // then
        await Assert.ThrowsAsync<UserValidationException>(
            testCode: async () => await addUserTask);

        this.storageBrokerMock.Verify(broker =>
            broker.InsertUserAsync(It.IsAny<User>()),
            Times.Never);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
