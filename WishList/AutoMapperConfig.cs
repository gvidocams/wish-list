using AutoMapper;
using WishList.Core.Models;
using WishList.Models;

namespace WishList
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WishRequest, Wish>();
                cfg.CreateMap<Wish, WishResponse>();
            });

            return config.CreateMapper();
        }
    }
}