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

            Order o1 = new Order { CustomerName = "Alexandra Pop", CustomerEmail = "pop.alexandra@gmail.com", CustomerPhone = "0755369547" };
            o1.Items.Add(new OrderItem { ProductName = "Laptop", Quantity = 1, Price = 999.99m });
            o1.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 3, Price = 24.99m });
            orders.Add(o1);

            Order o2 = new Order {CustomerName = "Andreea Popescu", CustomerEmail = "andreea.popescu@icloud.com", CustomerPhone = "0798635789" };
            o2.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 359.99m });
            o2.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 1, Price = 89.99m }); orders.Add(o2);

            Order o3 = new Order { CustomerName = "Dan Mihai", CustomerEmail = "dan.mihai@gmail.com", CustomerPhone = "0744894368" };
            o3.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 3, Price = 24.99m });
            orders.Add(o3);

            Order o4 = new Order {CustomerName = "Sara Zaharia", CustomerEmail = "zahariasara@gmail.com", CustomerPhone = "0744923478" };
            o4.Items.Add(new OrderItem { ProductName = "Smartphone", Quantity = 1, Price = 879.99m });
            orders.Add(o4);

            Order o5 = new Order { CustomerName = "Eliza Alexandrescu", CustomerEmail = "alexandrescu.zaharia@icloud.com", CustomerPhone = "0789896547" };
            o5.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 2, Price = 89.99m });
            o5.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 359.99m });
            o5.Items.Add(new OrderItem { ProductName = "Tablet", Quantity = 1, Price = 219.99m });
            orders.Add(o5);

            Order o6 = new Order { CustomerName = "David Popovici", CustomerEmail = "david.popovici@yahoo.com", CustomerPhone = "0787879012"};
            o6.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 2, Price = 89.99m });
            o6.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 1, Price = 359.99m });
            o6.Items.Add(new OrderItem { ProductName = "Tablet", Quantity = 1, Price = 219.99m });
            orders.Add(o6);

            Console.WriteLine("\nTop Spender: " + proc.GetTopSpender(orders));
            Console.WriteLine("\n-------------------");
            Console.WriteLine("\nPopular Products (Units Sold):");

            List<string> report = proc.GetPopularProductsReport(orders);
            foreach (string s in report)
            {
                Console.WriteLine("- " + s);
            }

            Console.WriteLine("\n-------------------");
            Console.WriteLine("\nORDER LIST:");
            foreach (var o in orders)
            {
                Console.WriteLine($"\nOrder ID: {o.OrderID} | Customer: {o.CustomerName}");
                foreach (var i in o.Items)
                {
                    Console.WriteLine($" Product: {i.ProductName} | Quantity: {i.Quantity} | Unit Price: {i.Price:F2} | Subtotal: {i.TotalPrice:F2}");
                }
                Console.WriteLine($"Total: {o.TotalAmount:F2}");
                Console.WriteLine($"Final Price: {proc.GetFinalPrice(o):F2}");

            }
            Console.ReadLine();
        }
    }
}