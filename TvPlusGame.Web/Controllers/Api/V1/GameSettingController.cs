using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TvPlusGame.DataAccess.Repository;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.DataAccess.Wrappers;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.Web.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameSettingController : BaseController
    {
        private readonly GameSettingRepository _repo;
        public GameSettingController(IUriService uriService, GameSettingRepository repo) : base(uriService)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("FinishGame")]
        public async Task<IActionResult> FinishGame()
        {
            var game = _repo.GetCurrentGame();
            if(game == null)
                return Ok(new Response<dynamic>() { Message = "بازی پیدا نشد" });
            game.EndGame = true;
            await _repo.Update(game);
            return Ok(new Response<dynamic>(game) { Message = "بازی با موفقیت پایان یافت" });
        }
        [HttpGet]
        [Route("StartGame")]
        public async Task<IActionResult> StartGame()
        {
            var game = _repo.GetCurrentGame();
            if (game != null)
            {
                game.EndGame = true;
                game.IsArchived = true;
                await _repo.Update(game);
            }
            var newGame = new GameSetting()
            {
                EndGame = false,
                IsArchived = false,
                ExpiredDate = DateTime.Now.AddMinutes(30)
            };
            await _repo.Add(newGame);
            return Ok(new Response<dynamic>(newGame) { Message = "بازی با موفقیت شروع شد زمان باقی مانده تا پایان 30 دقیقه" });
        }
    }
}
