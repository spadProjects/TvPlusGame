using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TvPlusGame.DataAccess.Dtos;
using TvPlusGame.Model.Entity;

namespace Visa.Infrastructure.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ForMember(u => u.Gender, opt => opt.MapFrom(m => m.Gender == 1? "Male" : "Female"));
            CreateMap<UserDto, User>();
        }
    }
}
