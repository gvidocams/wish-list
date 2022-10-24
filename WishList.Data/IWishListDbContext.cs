using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WishList.Core.Models;

namespace WishList.Data
{
    public interface IWishListDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Wish> Wishes { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}