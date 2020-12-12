using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using TvPlusGame.DataAccess.Dtos;
using TvPlusGame.DataAccess.Repository;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.DataAccess.Wrappers;
using TvPlusGame.Model.Entity;
using TvPlusGame.Web.Controllers.Api;

namespace TvPlusGame.Web.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthRepository _repo;
        private readonly GameSettingRepository _gameRepo;
        public AuthController(IAuthRepository repo, IUriService uriService, GameSettingRepository gameRepo) : base(uriService)
        {
            _repo = repo;
            _gameRepo = gameRepo;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            var token = await _repo.Login(user);
            if (token == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new LogInResponse<IActionResult>() {IsAccepted = false, Succeeded = false, Message = "نام یا رمز عبور وارد شده صحیح نیست" });
            var gameSetting = _gameRepo.GetCurrentGame();

            if (gameSetting == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new LogInResponse<IActionResult>() {IsAccepted = true, Succeeded = false, Message = "بازی پیدا نشد" });

            if (DateTime.Compare(DateTime.Now,gameSetting.ExpiredDate) >= 0  || gameSetting.EndGame == true)
                return StatusCode(StatusCodes.Status500InternalServerError, new LogInResponse<IActionResult>() { IsAccepted = true, Succeeded = false, Message = "بازی پایان یافته" });

            var userToken = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };
            return Ok(new LogInResponse<dynamic>(userToken) { Message = "توکن با موفقیت صادر شد" });
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(UserRegisterDto model)
        {
            var userExists = await _repo.UserExists(model.PhoneNumber); // We set phoneNumber as userName
            if (userExists)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<User>() { Succeeded = false, Message = "کاربر دیگری با همین شماره تلفن در سیستم ثبت شده" });


            var emailExists = await _repo.EmailExists(model.Email);
            if (emailExists)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<User>() { Succeeded = false, Message = "کاربر دیگری با همین ایمیل در سیستم ثبت شده" });

            var result = await _repo.Register(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<User>() { Succeeded = false, Message = "بت کاربر با مشکل مواجه شد لطفا ورودی های خود را چک کرده و مجددا تلاش کنید" });


            return Ok(new Response<UserDto>(result) { Message = "کاربر با موفقیت ثبت شد" });
        }
    }
}
