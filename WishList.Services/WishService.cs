using System.Linq;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Data;

namespace WishList.Services
{
    public class WishService : EntityService<Wish>, IWishService
    {
        private IEntityService<Wish> _entityService;

        public WishService(IWishListDbContext context, IEntityService<Wish> entityService) : base(context)
        {
            _entityService = entityService;
        }

        public bool Exists(Wish wish)
        {
            return _context.Wishes.Any(w => w.Description.ToLower() == wish.Description.ToLower());
        }

        public Wish Update(Wish wish, Wish newWish)
        {
            wish.Description = newWish.Description;

            _entityService.Update(wish);

            return wish;
        }
    }
}