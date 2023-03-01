using Application.Interfaces;
using Domain.Interface;
using Entitites.Entities;
using Entitites.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserApplication _userApplication;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSettings;


        public UserController(IUserApplication userApplication,
                                 SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser> userManager,
                                IOptions<AppSettings> appSettings)
        {

            _userApplication = userApplication;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }





        [AllowAnonymous]
        [HttpPost("/api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await _signInManager.PasswordSignInAsync(login.email, login.password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok( await NewToken(login.email));

            }
            

            return Ok(login);
        }


        [AllowAnonymous]

        [HttpPost("/api/AddUserIdentity")]
        public async Task<IActionResult> AddUserIdentity([FromBody] RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = registerUser.email,
                Email = registerUser.email,
                Age = registerUser.age,
                Cell = registerUser.cell,
                Type = TypeUsers.Commom,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.password);

            if (result.Errors.Any()) { return Ok(result.Errors); }


            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok( await NewToken(registerUser.email));
            }

            return Ok(registerUser);

        }




        private async Task<string> NewToken(string email)
        {


            var idUser = await _userApplication.ReturnUserId(email);
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
           


            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });


            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}