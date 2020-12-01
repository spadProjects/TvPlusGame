using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TvPlusGame.DataAccess.Repository;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.DataAccess.Wrappers;

namespace TvPlusGame.Web.Controllers.Api.V1
{
    public class GameSettingController : BaseController
    {
        private readonly GameSettingRepository _repo;
        public GameSettingController(IUriService uriService, GameSettingRepository repo) : base(uriService)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("finishgame")]
        public async Task<IActionResult> FinishGame()
        {
            var games = await _repo.GetAll();
            var game = games.FirstOrDefault();
            if(game == null)
                return Ok(new Response<dynamic>() { Message = "بازی پیدا نشد" });
            game.EndGame = true;
            await _repo.Update(game);
            return Ok(new Response<dynamic>(game) { Message = "بازی با موفقیت پایان یافت" });
        }
        [HttpGet]
        [Route("startgame")]
        public async Task<IActionResult> StartGame()
        {
            var games = await _repo.GetAll();
            var game = games.FirstOrDefault();
            if (game == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response<IActionResult>() {Succeeded = false, Message = "بازی پیدا نشد"});

            game.EndGame = false;
            game.ExpiredDate = DateTime.Now.AddMinutes(30);
            await _repo.Update(game);
            return Ok(new Response<dynamic>(game) { Message = "بازی با موفقیت شروع شد زمان باقی مانده تا پایان 30 دقیقه" });
        }
    }
}
