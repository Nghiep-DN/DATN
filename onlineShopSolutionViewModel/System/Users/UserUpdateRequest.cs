using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Date of birthday")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
