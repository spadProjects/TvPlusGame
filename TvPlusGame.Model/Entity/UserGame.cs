using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlusGame.Model.Entity
{
    public class UserGame
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Coin { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
