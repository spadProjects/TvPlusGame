using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlusGame.DataAccess.Services;
using TvPlusGame.Web.Auth;

namespace TvPlusGame.Web.Controllers.Api
{
    [ApiKeyAuth]
    public class BaseController : ControllerBase
    {
        public readonly IUriService uriService;
        public BaseController(IUriService uriService)
        {
            this.uriService = uriService;
        }
    }
}
