using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlusGame.DataAccess.Dtos
{
    public class UserRegisterDto
    {
        [EmailAddress(ErrorMessage = "ایمیل نا معتبر.")]
        [Required(ErrorMessage = "ایمیل را وارد کنید.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پسورد را وارد کنید.")]
        [StringLength(100, ErrorMessage = "پسورد باید حداقل 6 کارکتر باشد", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
            ErrorMessage = "پسورد باید بیشتر از 6 کارکتر و حداقل شامل یک حرف بزرگ یک حرف کوچک یک عدد و یک کارکتر خاص باشد.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        // ErrorMessage = "پسورد باید بیشتر از 8 کارکتر بوده و حداقل شامل یک حرف بزرگ یک حرف کوچک یک عدد و یک کارکتر خاص باشد.")]
        public string Password { get; set; }

        [MaxLength(300, ErrorMessage = "نام شما باید از 300 کارکتر کمتر باشد")]
        [Required(ErrorMessage = "نام خود را وارد کنید.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "سال تولد خود را وارد کنید.")]
        public int BirthYear { get; set; }
        [Required(ErrorMessage = "جنسیت خود را وارد کنید.")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "شماره تلفن را وارد کنید.")]
        public string PhoneNumber { get; set; }

    }
}
