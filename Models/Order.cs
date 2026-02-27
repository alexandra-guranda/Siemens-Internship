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
        public DateTime OrderDate { get; private set; }
        public Customer CustomerOrder { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        
        public Order()
        {
            counterId++;
            this.OrderID = counterId;
            this.OrderDate = DateTime.Now;
        }
    }
}
