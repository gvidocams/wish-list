using WishList.Core.Models;

namespace WishList.Core.Services
{
    public interface IWishService : IEntityService<Wish>
    {
        bool Exists(Wish wish);
        Wish Update(Wish wish, Wish newWish);
    }
}