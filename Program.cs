using System;
using System.Collections.Generic;
using SieMarket.Models;
using SieMarket.Services;

namespace SieMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor processor = new OrderProcessor();
            List<Order> orders = new List<Order>();

            Customer alexandra = new Customer { name = "Alexandra Pop", email = "pop.alexandra@gmail.com", phone = "0755369547" };
            Customer andreea = new Customer { name = "Andreea Popescu", email = "andreea.popescu@icloud.com", phone = "0798635789" };
            Customer dan = new Customer { name = "Dan Mihai", email = "dan.mihai@gmail.com", phone = "0744894368" };
            Customer sara = new Customer { name = "Sara Zaharia", email = "zahariasara@gmail.com", phone = "0744923478" };
            Customer eliza = new Customer { name = "Eliza Alexandrescu", email = "alexandrescu.zaharia@icloud.com", phone = "0789896547" };
            Customer david = new Customer { name = "David Popovici", email = "david.popovici@yahoo.com", phone = "0787879012" };

            Order o1 = new Order { customerData = alexandra };
            o1.items.Add(new OrderItem { productName = "Laptop", quantity = 1, price = 999.99m });
            o1.items.Add(new OrderItem { productName = "Mouse", quantity = 3, price = 24.99m });
            orders.Add(o1);

            Order o2 = new Order { customerData = andreea };
            o2.items.Add(new OrderItem { productName = "Monitor", quantity = 1, price = 359.99m });
            o2.items.Add(new OrderItem { productName = "Keyboard", quantity = 1, price = 89.99m });
            orders.Add(o2);

            Order o3 = new Order { customerData = dan };
            o3.items.Add(new OrderItem { productName = "Mouse", quantity = 2, price = 24.99m });
            orders.Add(o3);

            Order o4 = new Order { customerData = sara };
            o4.items.Add(new OrderItem { productName = "Smartphone", quantity = 1, price = 879.99m });
            orders.Add(o4);

            Order o5 = new Order { customerData = eliza };
            o5.items.Add(new OrderItem { productName = "Keyboard", quantity = 2, price = 89.99m });
            o5.items.Add(new OrderItem { productName = "Monitor", quantity = 1, price = 359.99m });
            o5.items.Add(new OrderItem { productName = "Tablet", quantity = 1, price = 219.99m });
            orders.Add(o5);

            Order o6 = new Order { customerData = david };
            o6.items.Add(new OrderItem { productName = "Keyboard", quantity = 2, price = 89.99m });
            o6.items.Add(new OrderItem { productName = "Monitor", quantity = 1, price = 359.99m });
            o6.items.Add(new OrderItem { productName = "Tablet", quantity = 1, price = 219.99m });
            orders.Add(o6);

            Console.WriteLine("Top Spender: " + processor.GetTopSpender(orders));
            Console.WriteLine("\n-------------");
            Console.WriteLine("\nPopular Products (Units Sold):");

            List<string> report = processor.GetPopularProductsReport(orders);
            foreach (string s in report)
            {
                Console.WriteLine("\n- " + s);
            }

            Console.WriteLine("\n-------------");
            Console.WriteLine("\nOrder List:");
            foreach (var o in orders)
            {
                Console.WriteLine($"\nOrder ID: {o.orderId} | Date: {o.orderDate:dd/MM/yyyy HH:mm} | Customer: {o.customerData.name}");

                foreach (var i in o.items)
                {
                    Console.WriteLine($"  Product: {i.productName,-12} | Qty: {i.quantity} | Unit: {i.price,8:N2} | Subtotal: {i.totalPrice,8:N2}");
                }
                Console.WriteLine($"  Total: {o.totalAmount:N2} | Final Price: {processor.GetFinalPrice(o):N2}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}