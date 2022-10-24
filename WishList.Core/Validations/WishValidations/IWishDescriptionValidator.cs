using WishList.Core.Models;

namespace WishList.Core.Validations.WishValidations
{
    public interface IWishDescriptionValidator
    {
        bool IsValid(Wish wish);
    }
}