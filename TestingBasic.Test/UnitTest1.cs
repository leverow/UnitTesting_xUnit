using Xunit;

namespace TestingBasic.Test;

public class UserManagementTest
{
    [Fact]
    public void AddUserMethodShouldReturnValidData()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new(
                "Azamjon", "Bakhriddin"
        ));

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.NotNull(savedUser);
        Assert.Equal("Azamjon", savedUser.FirstName);
        Assert.Equal("Bakhriddin", savedUser.LastName);
        Assert.NotEmpty(savedUser.Phone);
        Assert.False(savedUser.VerifiedEmail);
    }

    [Fact]
    public void VerifyEmailShouldReturnTrueWhenVerificationMethodRuns()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new(
                "Azamjon", "Bakhriddin"
        ));

        var firstUser = userManagement.AllUsers.ToList().First();
        userManagement.VerifyEmail(firstUser.Id);

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.True(savedUser.VerifiedEmail);
    }

    [Fact]
    public void UpdateShouldReturnValidMobileNumber()
    {
        // Arrange
        var userManagement = new UserManagement();

        // Act
        userManagement.Add(new(
                "Azamjon", "Bakhriddinov"
        ));

        var firstUser = userManagement.AllUsers.ToList().First();
        firstUser.Phone = "+998991234567";
        userManagement.UpdatePhone(firstUser);

        // Assert
        var savedUser = Assert.Single(userManagement.AllUsers);
        Assert.Equal("+998991234567",savedUser.Phone);
    }
}