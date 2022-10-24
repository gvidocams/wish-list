using FluentAssertions;
using WishList.Core.Models;
using WishList.Core.Validations.UserValidations;
using Xunit;

namespace WishList.Tests.UserTests
{
    public class UserTypeTests
    {
        private UserTypeValidator _validator = new UserTypeValidator();

        [Fact]
        public void UserType_PassesNullValue_ReturnsFalse()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = "john.doe@example.com",
                    Name = "John Doe",
                    Type = null
                }
            };

            _validator.IsValid(users).Should().BeFalse();
        }

        [Fact]
        public void UserType_PassesEmptyValue_ReturnsFalse()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = "john.doe@example.com",
                    Name = "John Doe",
                    Type = ""
                }
            };

            _validator.IsValid(users).Should().BeFalse();
        }

        [Fact]
        public void UserType_PassesValidValue_ReturnsTrue()
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