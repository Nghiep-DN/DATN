using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
   public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name ="Date of birthday")]
        public DateTime DOB { get; set; }
        public IList<string> Roles { get; set; }
    }
}
