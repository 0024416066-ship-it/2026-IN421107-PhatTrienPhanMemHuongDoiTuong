using EduHub.Ch02.Domain;

namespace Ch02.Refactor.Tests;

public class DomainTests
{
    [Fact]
    public void Club_Create_WithValidName_ReturnsClubWithNewId()
    {
        // Arrange
        const string name = "Tech Club";

        // Act
        var club = Club.Create(name, "Technology community");

        // Assert
        Assert.Equal(name, club.Name);
        Assert.NotEqual(Guid.Empty, club.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Club_Create_WithBlankName_ThrowsArgumentException(string name)
    {
        // Arrange / Act
        var act = () => Club.Create(name, "Description");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithNameLongerThanMaximum_ThrowsArgumentException()
    {
        // Arrange
        var name = new string('a', Club.MaxNameLength + 1);

        // Act
        var act = () => Club.Create(name, "Description");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData(49, true)]
    [InlineData(50, false)]
    public void Club_HasRoom_AtCapacityBoundary_ReturnsExpectedResult(int count, bool expected)
    {
        // Arrange
        var club = Club.Create("Tech Club", "Description");

        // Act
        var result = club.HasRoom(count);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = NewEvent();
        var memberId = Guid.NewGuid();

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.True(result);
        Assert.Contains(memberId, ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = NewEvent();
        var memberId = Guid.NewGuid();
        ev.Register(memberId);

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.False(result);
        Assert.Single(ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = NewEvent();

        // Act
        var act = () => ev.CheckIn(Guid.NewGuid());

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Event_AttendanceRate_WithNoRegistrations_IsZero()
    {
        // Arrange
        var ev = NewEvent();

        // Act
        var rate = ev.AttendanceRate;

        // Assert
        Assert.Equal(0, rate);
    }

    private static Event NewEvent() => new()
    {
        Id = Guid.NewGuid(),
        ClubId = Guid.NewGuid(),
        Title = "Workshop",
        Date = new DateTime(2026, 11, 20)
    };
}
