using FluentAssertions;
using WishList.Core.Models;
using WishList.Core.Validations.UserValidations;
using Xunit;

namespace WishList.Tests.UserTests
{
    public class UserNameTests
    {
        private UserNameValidator _validator = new UserNameValidator();

        [Fact]
        public void UserName_PassesNullValue_ReturnsFalse()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = "john.doe@example.com",
                    Name = null,
                    Type = "User"
                }
            };

            _validator.IsValid(users).Should().BeFalse();
        }

        [Fact]
        public void UserName_PassesEmptyValue_ReturnsFalse()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = "john.doe@example.com",
                    Name = "",
                    Type = "User"
                }
            };

            _validator.IsValid(users).Should().BeFalse();
        }

        [Fact]
        public void UserName_PassesValidValue_ReturnsTrue()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = "john.doe@example.com",
                    Name = "John Doe",
                    Type = "User"
                }
            };

            _validator.IsValid(users).Should().BeTrue();
        }
    }
}