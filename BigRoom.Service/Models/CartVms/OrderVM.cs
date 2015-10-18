﻿using System.Collections.Generic;

namespace BigRoom.Service.Models.CartVms
{
    public class OrderVM
    {
        public OrderVM()
        {
            this.Items = new List<CartItemVM>();
            this.Customer = new CustomerVM();
            this.Payment = new PaymentVM();
        }

        public decimal Subtotal { get; set; }
        public decimal ShippingTotal { get; set; }
        public string Comment { get; set; }

        public CustomerVM Customer { get; set; }
        public PaymentVM Payment { get; set; }
        public List<CartItemVM> Items { get; set; }
    }
}