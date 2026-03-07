using FluentAssertions;
using Moq;
using Mulkchi.Api.Models.Foundations.Users;

namespace Mulkchi.Api.Tests.Unit.Tests.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public void ShouldRetrieveAllUsers()
    {
        // given
        IQueryable<User> randomUsers = new List<User>
        {
            CreateRandomUser(),
            CreateRandomUser(),
            CreateRandomUser()
        }.AsQueryable();

        IQueryable<User> expectedUsers = randomUsers;

        this.storageBrokerMock.Setup(broker =>
            broker.SelectAllUsers())
                .Returns(expectedUsers);

        // when
        IQueryable<User> actualUsers = this.userService.RetrieveAllUsers();

        // then
        actualUsers.Should().BeEquivalentTo(expectedUsers);

        this.storageBrokerMock.Verify(broker =>
            broker.SelectAllUsers(),
            Times.Once);

        this.storageBrokerMock.VerifyNoOtherCalls();
    }
}
