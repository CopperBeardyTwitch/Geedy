using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GeedService.Interfaces;
using GeedService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GeedService.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("working");
        }


[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> UserProfile(string id)
        {
            //var scopes = HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            //if (!string.IsNullOrEmpty(Startup.ScopeRead) && scopes != null
            //                                             && scopes.Split(' ').Any(s => s.Equals(Startup.ScopeRead)))
            //{

                var result = await _userRepository.GetUserById(id);
                var user =
                    new CurrentUserPublicProfile
                    {
                        User = result,
                        //todo: implment calculating average
                        UserAverageRating = 1,
                        //todo: implement get totoal rating count
                        RatingCount = 2,
                        //todo: implment getting latestrating
                        LatestRatings = new List<LatestRating>()

                    };
                return Ok(user);
            //}
            //else
            //{
            //    return Unauthorized();
            //}


        }
    }
}