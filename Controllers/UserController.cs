using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TODO.Data.Models;
using TODO.Data.DTO;

namespace TODO.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase{
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(
            UserManager<IdentityUser> userManager
        )
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(UserCreateDto user){
            var identityUser = new IdentityUser(){UserName=user.UserName,Email=user.Email};
            var result  = await _userManager.CreateAsync(identityUser,user.Password);
            if (!result.Succeeded){
                return BadRequest(result.Errors);
            }
            var userDetail = new UserDetailDto(){
                Id = identityUser.Id,
                UserName=user.UserName,
                Email=user.Email,
            };
            return Created(nameof(RegisterUser),userDetail);
        } 

        [HttpGet("{id}/get")]
        public async Task<ActionResult<User>> GetDetailUserInfo(string id){
            var user = await _userManager.FindByIdAsync(id);
            if (user == null){
                return NotFound();
            }
            var userDetail = new UserDetailDto(){
                Id = user.Id,
                UserName=user.UserName,
                Email=user.Email,

            };
            return Ok(userDetail);
        }

    }

}