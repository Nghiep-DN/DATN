using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Sales
{
    public class CheckoutRequest //thoong tin day vao bang? Order
    {
       // public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public OrderStatus Status { get; set; }

        public List<OrderDetailViewModel> OrderDetails { get; set; } = new List<OrderDetailViewModel>();
    }
}
