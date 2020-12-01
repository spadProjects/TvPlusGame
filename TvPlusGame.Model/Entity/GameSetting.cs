using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlusGame.Model.Entity
{
   public class GameSetting : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool EndGame { get; set; }
    }
}
