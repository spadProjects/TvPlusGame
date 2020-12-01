using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlusGame.DataAccess.Dtos
{
    public class UserEditDto
    {
        [EmailAddress(ErrorMessage = "ایمیل نا معتبر.")]
        [Required(ErrorMessage = "ایمیل را وارد کنید.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "نام کاربری را وارد کنید.")]
        public string UserName { get; set; }

        [MaxLength(300, ErrorMessage = "نام باید از 300 کارکتر کمتر باشد")]
        [Required(ErrorMessage = "نام را وارد کنید.")]
        public string FirstName { get; set; }

        [MaxLength(300, ErrorMessage = "نام خانوادگی باید از 300 کارکتر کمتر باشد")]
        [Required(ErrorMessage = "نام خانوادگی را وارد کنید.")]
        public string LastName { get; set; }
        public string Information { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
