using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishList.Core.Models;

namespace WishList.Data
{
    public class WishListDbContext : DbContext, IWishListDbContext
    {
        public WishListDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Wish> Wishes { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
