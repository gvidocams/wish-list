using FluentAssertions;
using WishList.Core.Models;
using WishList.Core.Validations.UserValidations;
using WishList.Core.Validations.WishValidations;
using Xunit;

namespace WishList.Tests.WishTests
{
    public class WishDescription_Tests
    {
        private WishDescriptionValidator _validator = new WishDescriptionValidator();

        [Fact]
        public void WishDescription_PassesNullValue_ReturnsFalse()
        {
            var wish = new Wish
            {
                Description = null
            };

            _validator.IsValid(wish).Should().BeFalse();
        }

        [Fact]
        public void WishDescription_PassesEmptyValue_ReturnsFalse()
        {
            var wish = new Wish
            {
                Description = ""
            };

            _validator.IsValid(wish).Should().BeFalse();
        }

        [Fact]
        public void WishDescription_PassesValidValue_ReturnsTrue()
        {
            var wish = new Wish
            {
                Description = "To code"
            };

            _validator.IsValid(wish).Should().BeTrue();
        }
    }
}