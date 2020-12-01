using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlusGame.DataAccess.Dtos
{
    public class UserCreateDto
    {
        [EmailAddress(ErrorMessage = "ایمیل نا معتبر.")]
        [Required(ErrorMessage = "ایمیل را وارد کنید.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "نام کاربری را وارد کنید.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "پسورد را وارد کنید.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
         ErrorMessage = "پسورد باید بیشتر از 8 کارکتر بوده و حداقل شامل یک حرف بزرگ یک حرف کوچک یک عدد و یک کارکتر خاص باشد.")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        [MaxLength(300, ErrorMessage = "نام باید از 300 کارکتر کمتر باشد")]
        [Required(ErrorMessage = "نام را وارد کنید.")]
        public string FirstName { get; set; }

        [MaxLength(300, ErrorMessage = "نام خانوادگی باید از 300 کارکتر کمتر باشد")]
        [Required(ErrorMessage = "نام خانوادگی را وارد کنید.")]
        public string LastName { get; set; }
        public string Information { get; set; }

    }
}
