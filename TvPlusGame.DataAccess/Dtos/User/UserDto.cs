using System;
using System.ComponentModel.DataAnnotations;

namespace TvPlusGame.DataAccess.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Coins { get; set; }
        public int BirthYear { get; set; }
        public string Gender { get; set; }
        public string Information { get; set; }
    }
}
