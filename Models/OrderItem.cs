using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarket.Models
{
    public class OrderItem
    {
        public string productName { get; set; }
        public int  quantity { get; set; }
        public decimal price { get; set; }
        public decimal totalPrice => quantity * price;
    }

}
