using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TvPlusGame.DataAccess.Dtos;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.DataAccess.Repository
{
    public interface IAuthRepository
    {
        Task<JwtSecurityToken> Login(UserLoginDto model);
        Task<UserDto> Register(UserRegisterDto model);
        Task<bool> UserExists(string username, string id = null);
        Task<bool> EmailExists(string email, string id = null);
    }
    public class AuthRepsitory : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;


        public AuthRepsitory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<JwtSecurityToken> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            // in case the input is the user's email address
            if (user == null)
                user = await _userManager.FindByEmailAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim("unique_name", user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim("role", userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return token;
            }
            return null;
        }
        public async Task<UserDto> Register(UserRegisterDto model)
        {
            User user = new User()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.PhoneNumber,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                BirthYear = model.BirthYear,
                RegisterDate = DateTime.Now,
                Gender = model.Gender
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(UserRoles.Player))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Player));

                await _userManager.AddToRoleAsync(user, UserRoles.Player);
            }
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
        public async Task<bool> UserExists(string username, string id = null)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (string.IsNullOrEmpty(id))
                {
                    if (user != null)
                        return true;
                }
                else
                {
                    if (user.Id != id)
                        return true;
                }
            }
            return false;
        }
        public async Task<bool> EmailExists(string email, string id = null)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (string.IsNullOrEmpty(id))
                {
                    if (user != null)
                        return true;
                }
                else
                {
                    if (user.Id != id)
                        return true;
                }
            }
            return false;
        }
    }
}
