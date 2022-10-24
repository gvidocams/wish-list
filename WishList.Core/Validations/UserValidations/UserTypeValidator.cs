using System.Linq;
using WishList.Core.Models;

namespace WishList.Core.Validations.UserValidations
{
    public class UserTypeValidator : IUserValidations
    {
        public bool IsValid(User[] user)
        {
            return !user.Any(u => string.IsNullOrEmpty(u.Type));
        }
    }
}