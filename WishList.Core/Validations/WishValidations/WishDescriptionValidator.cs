using WishList.Core.Models;

namespace WishList.Core.Validations.WishValidations
{
    public class WishDescriptionValidator : IWishDescriptionValidator
    {
        public bool IsValid(Wish wish)
        {
            return !string.IsNullOrEmpty(wish.Description);
        }
    }
}