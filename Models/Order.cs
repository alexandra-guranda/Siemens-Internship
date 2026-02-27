using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarket.Models
{
    public class Order
    {
        private static int counterId = 100;

        public int OrderID { get; private set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        
        public Order()
        {
            counterId++;
            this.OrderID = counterId;
        }
    }
}
