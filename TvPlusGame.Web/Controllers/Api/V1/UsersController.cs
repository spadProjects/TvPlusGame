using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TvPlusGame.DataAccess.Dtos;
using TvPlusGame.DataAccess.Repository;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.DataAccess.Wrappers;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.Web.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        public readonly UserManager<User> _userManager;
        public UsersController(IUriService uriService, IUsersRepository repo, IMapper mapper, UserManager<User> userManager) : base(uriService)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetCurrentUser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var headers = HttpContext.Request.Headers;
            var bearerToken = (string)headers.FirstOrDefault(h => h.Key == "Authorization").Value;
            var uniqueName = TokenService.GetUniqueNameFromToken(bearerToken);
            var user = await _repo.GetUserByUserName(uniqueName);
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new Response<dynamic>(userDto) { Message = "اطلاعات کاربر با موفقیت صادر شد" });
        }
        [HttpPost]
        [Route("SaveUserCoins")]
        [Authorize]
        public async Task<IActionResult> SaveUserCoins(int coins)
        {
            var headers = HttpContext.Request.Headers;
            var bearerToken = (string)headers.FirstOrDefault(h => h.Key == "Authorization").Value;
            var uniqueName = TokenService.GetUniqueNameFromToken(bearerToken);
            var user = await _repo.GetUserByUserName(uniqueName);
            user.Coins += coins;
            await _userManager.UpdateAsync(user);
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new Response<dynamic>(userDto) { Message = "سکه های کاربر با موفقیت ذخیره شد" });
        }
    }
}
