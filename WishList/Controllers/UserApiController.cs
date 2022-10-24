using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishList.Core.Extensions;
using WishList.Core.Models;
using WishList.Core.Validations.UserValidations;

namespace WishList.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IEnumerable<IUserValidations> _validations;

        public UserApiController(IEnumerable<IUserValidations> validations)
        {
            _validations = validations;
        }

        [HttpPost]
        public IActionResult GetNames(User[] users)
        {
            if (_validations.Any(u => !u.IsValid(users)))
            {
                return BadRequest();
            }

            var response = users.Names();

            return Ok(response);
        }
    }
}
