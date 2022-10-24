using System.Linq;
using WishList.Core.Models;

namespace WishList.Core.Extensions
{
    public static class NamesExtension
    {
        public static string Names(this User[] users)
        {
            return string.Join(", ", users.Select(u => u.Name));
        }
    }
}