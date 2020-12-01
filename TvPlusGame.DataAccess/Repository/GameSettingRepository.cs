using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TvPlusGame.DataAccess.Context;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.DataAccess.Repository
{
    public class GameSettingRepository : BaseRepository<GameSetting, MyDbContext>
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public GameSettingRepository(MyDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
