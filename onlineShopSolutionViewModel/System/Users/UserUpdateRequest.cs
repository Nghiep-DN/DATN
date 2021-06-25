using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
    public class UserUpdateRequest
    {
        [Display(Name = "Tên")]
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
