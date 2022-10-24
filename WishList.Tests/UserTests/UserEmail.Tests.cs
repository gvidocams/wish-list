using System;
using FluentAssertions;
using WishList.Core.Models;
using WishList.Core.Validations.UserValidations;
using Xunit;

namespace WishList.Tests.UserTests
{
    public class UserEmailTests
    {
        private UserEmailValidator _validator = new UserEmailValidator();

        [Fact]
        public void UserEmail_PassesNullValue_ReturnsFalse()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = null,
                    Name = "John Doe",
                    Type = "User"
                }
            };

            _validator.IsValid(users).Should().BeFalse();
        }

        [Fact]
        public void UserEmail_PassesEmptyValue_ReturnsFalse()
        {
            var users = new[]
            {
                new User
                {
                    Id = 0,
                    Email = "",
                    Name = "John Doe",
                    Type = "User"
                }
            };

            _validator.IsValid(users).Should().BeFalse();
        }

        [Fact]
        public void UserEmail_PassesValidValue_ReturnsTrue()
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
