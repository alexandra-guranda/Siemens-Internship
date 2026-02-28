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

        public int orderId { get; private set; }
        public DateTime orderDate { get; private set; }
        public Customer customerData { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
        public decimal totalAmount => items.Sum(item => item.totalPrice);
        
        public Order()
        {
            counterId++;
            this.orderId = counterId;
            this.orderDate = DateTime.Now;
        }
    }
}
