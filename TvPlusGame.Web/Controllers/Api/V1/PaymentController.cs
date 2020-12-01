using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.DataAccess.Wrappers;

namespace TvPlusGame.Web.Controllers.Api.V1
{
    public class PaymentController : BaseController
    {
        public PaymentController(IUriService uriService) : base(uriService)
        {
        }
        [HttpGet]
        [Route("Callback")]
        public async Task<IActionResult> Callback()
        {
            return Ok(new Response<dynamic>() {Succeeded = true, Message = "متد کالبک درگاه پرداخت" });
        }
    }
}
