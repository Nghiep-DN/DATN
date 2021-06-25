using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
    public class RegisterRequest
    {
        [Display(Name ="Tên")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Display(Name ="Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
