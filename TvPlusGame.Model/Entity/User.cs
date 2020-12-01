using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlusGame.Model.Entity
{
    public class User : IdentityUser
    {
        public string Avatar { get; set; }
        [MaxLength(600)]
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Coins { get; set; }
        public int BirthYear { get; set; }
        public int Gender { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}
