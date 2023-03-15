using Microsoft.AspNetCore.Mvc;
using TODO.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using System.Text.Json.Serialization;
using TODO.Data.DTO;
namespace TODO.Controllers {

    [ApiController]
    [Route("api/auth/[controller]")]
    public class AuthController: ControllerBase{
        private readonly ApplicationDbContext  _db ;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager
        )
        {
            _db=db;
            _userManager=userManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(string username, string password ){
            var user = await _userManager.FindByNameAsync(username);
            if (user==null){
                var detailDto = new ErrorDetailDto{
                    detail="Wrong password or username"
                };
                var jsonResponse =  JsonSerializer.Serialize(detailDto);
                return NotFound(jsonResponse);
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user,password);
            if (checkPassword == false){
                var detailDto = new ErrorDetailDto{
                    detail="Wrong password or username"
                };
                var jsonResponse = JsonSerializer.Serialize(detailDto);
                return BadRequest(jsonResponse);
            }
            var claims = new List<Claim>{new Claim(ClaimTypes.Name,username)};
            var signingCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer:AuthOptions.ISSUER,
                audience:AuthOptions.AUDIENCE,
                claims: claims,
                expires:DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: signingCredentials
            );
            var resp = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Ok(resp);
        }
    }
}