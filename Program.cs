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
            OrderProcessor proc = new OrderProcessor();
            List<Order> orders = new List<Order>();

            Customer alexandra = new Customer { Name = "Alexandra Pop", Email = "pop.alexandra@gmail.com", Phone = "0755369547" };
            Customer andreea = new Customer { Name = "Andreea Popescu", Email = "andreea.popescu@icloud.com", Phone = "0798635789" };
            Customer dan = new Customer { Name = "Dan Mihai", Email = "dan.mihai@gmail.com", Phone = "0744894368" };
            Customer sara = new Customer { Name = "Sara Zaharia", Email = "zahariasara@gmail.com", Phone = "0744923478" };
            Customer eliza = new Customer { Name = "Eliza Alexandrescu", Email = "alexandrescu.zaharia@icloud.com", Phone = "0789896547" };
            Customer david = new Customer { Name = "David Popovici", Email = "david.popovici@yahoo.com", Phone = "0787879012" };

            Order o1 = new Order { CustomerOrder = alexandra };
            o1.Items.Add(new OrderItem { ProductName = "Laptop", Quantity = 1, Price = 999.99m });
            o1.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 3, Price = 24.99m });
            orders.Add(o1);

            Order o2 = new Order { CustomerOrder = andreea };
            o2.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 359.99m });
            o2.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 1, Price = 89.99m });
            orders.Add(o2);

            Order o3 = new Order { CustomerOrder = dan };
            o3.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 2, Price = 24.99m });
            orders.Add(o3);

            Order o4 = new Order { CustomerOrder = sara };
            o4.Items.Add(new OrderItem { ProductName = "Smartphone", Quantity = 1, Price = 879.99m });
            orders.Add(o4);

            Order o5 = new Order { CustomerOrder = eliza };
            o5.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 2, Price = 89.99m });
            o5.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 359.99m });
            o5.Items.Add(new OrderItem { ProductName = "Tablet", Quantity = 1, Price = 219.99m });
            orders.Add(o5);

            Order o6 = new Order { CustomerOrder = david };
            o6.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 2, Price = 89.99m });
            o6.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 359.99m });
            o6.Items.Add(new OrderItem { ProductName = "Tablet", Quantity = 1, Price = 219.99m });
            orders.Add(o6);

            Console.WriteLine("Top Spender: " + proc.GetTopSpender(orders));
            Console.WriteLine("\n-------------");
            Console.WriteLine("\nPopular Products (Units Sold):");

            List<string> report = proc.GetPopularProductsReport(orders);
            foreach (string s in report)
            {
                Console.WriteLine("\n- " + s);
            }

            Console.WriteLine("\n-------------");
            Console.WriteLine("\nOrder List:");
            foreach (var o in orders)
            {
                Console.WriteLine($"\nOrder ID: {o.OrderID} | Date: {o.OrderDate:dd/MM/yyyy HH:mm} | Customer: {o.CustomerOrder.Name}");

                foreach (var i in o.Items)
                {
                    Console.WriteLine($"  Product: {i.ProductName,-12} | Qty: {i.Quantity} | Unit: {i.Price,8:N2} | Subtotal: {i.TotalPrice,8:N2}");
                }
                Console.WriteLine($"  Total: {o.TotalAmount:N2} | Final Price: {proc.GetFinalPrice(o):N2}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}