using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Core.Validations.WishValidations;
using WishList.Data;
using WishList.Models;
using WishList.Services;

namespace WishList.Controllers
{
    [Route("api/wish")]
    [ApiController]
    public class WishApiController : ControllerBase
    {
        private readonly IWishService _wishService;
        private readonly IWishDescriptionValidator _validator;
        private readonly IMapper _mapper;

        public WishApiController(
            IWishService wishService,
            IWishDescriptionValidator validator,
            IMapper mapper)
        {
            _wishService = wishService;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllWishes()
        {
            var wishes = _wishService.GetAll().ConvertAll(w => _mapper.Map<WishResponse>(w));

            return Ok(wishes.ToArray());
        }
        
        [HttpGet, Route("{id}")]
        public IActionResult GetWish(int id)
        {
            var wish = _wishService.GetById(id);

            if (wish == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<WishResponse>(wish);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PutWish(WishRequest request)
        {
            var wish = _mapper.Map<Wish>(request);

            if (!_validator.IsValid(wish))
            {
                return BadRequest();
            }

            if (_wishService.Exists(wish))
            {
                return Conflict();
            }

            _wishService.Create(wish);

            var response = _mapper.Map<WishResponse>(wish);

            return Ok(response);
        }
        
        [HttpPatch, Route("{id}")]
        public IActionResult UpdateWish(int id, WishRequest request)
        {
            var newWish = _mapper.Map<Wish>(request);

            if (!_validator.IsValid(newWish))
            {
                return BadRequest();
            }

            var wish = _wishService.GetById(id);

            if (wish == null)
            {
                return NotFound();
            }

            wish = _wishService.Update(wish, newWish);

            var response = _mapper.Map<WishResponse>(wish);

            return Ok(response);
        }
        
        [HttpDelete, Route("{id}")]
        public IActionResult DeleteWish(int id)
        {
            var wish = _wishService.GetById(id);

            if (wish == null)
            {
                return NotFound();
            }

            _wishService.Delete(wish);

            return Ok();
        }
    }
}
