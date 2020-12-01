using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TvPlusGame.DataAccess.Repository;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.DataAccess.Wrappers;

namespace TvPlusGame.Web.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUsersRepository _repo;
        public UsersController(IUriService uriService, IUsersRepository repo) : base(uriService)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetUserByUserName")]
        [Authorize]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            //var handler = new JwtSecurityTokenHandler();
            //var token = handler.ReadJwtToken(jwtToken);
            //var name = token.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
            //    .Select(c => c.Value).SingleOrDefault();
            var a = HttpContext.Request.Headers;
            var user = await _repo.GetUserByUserName(userName);
            return Ok(new Response<dynamic>(user) { Message = "اطلاعات کاربر با موفقیت صادر شد" });
        }
    }
}
