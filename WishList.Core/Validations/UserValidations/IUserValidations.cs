using WishList.Core.Models;

namespace WishList.Core.Validations.UserValidations
{
    public interface IUserValidations
    {
        bool IsValid(User[] user);
    }
}