using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
   public class UserViewModel
    {
        public Guid Id { get; set; }
        [Display(Name ="Tên")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name ="Ngày sinh")]
        public DateTime DOB { get; set; }
        public IList<string> Roles { get; set; }
    }
}
