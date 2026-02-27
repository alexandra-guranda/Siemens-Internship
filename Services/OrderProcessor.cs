using System.Collections.Generic;
using SieMarket.Models;

namespace SieMarket.Services
{
    public class OrderProcessor
    {
        public decimal GetFinalPrice(Order order)
        {
            decimal total = order.TotalAmount;
            if(total > 500)
                return total * 0.9m;
            return total;
        }

        public string GetTopSpender(List<Order> orders)
        {
            if (orders == null || orders.Count == 0) return "";

            List<Customer> totals = new List<Customer>();

            foreach (var o in orders)
            {
                decimal price = GetFinalPrice(o);
                Customer found = null;

                foreach (var t in totals)
                {
                    if (t.Name == o.CustomerName)
                    {
                        found = t;
                        break;
                    }
                }

                if (found != null)
                {
                    found.Amount += price;
                }
                else
                {
                    Customer ct = new Customer();
                    ct.Name = o.CustomerName;
                    ct.Amount = price;
                    ct.Email = o.CustomerEmail;
                    ct.Phone = o.CustomerPhone;
                    totals.Add(ct);
                }
            }

            decimal max = -1;
            foreach (var t in totals)
            {
                if (t.Amount > max)
                {
                    max = t.Amount;
                }
            }

            string topNames = "";
            foreach (var t in totals)
            {
                if (t.Amount == max)
                {
                    if (topNames == "")
                    {
                        topNames = t.Name;
                    }
                    else
                    {
                        topNames = topNames + ", " + t.Name;
                    }
                }
            }

            return topNames;
        }

        public List<string> GetPopularProductsReport(List<Order> orders)
        {
            List<string> names = new List<string>();
            List<int> qtys = new List<int>();

            foreach (var o in orders)
            {
                foreach (var i in o.Items)
                {
                    int idx = -1;
                    for (int j = 0; j < names.Count; j++)
                    {
                        if (names[j] == i.ProductName)
                        {
                            idx = j;
                            break;
                        }
                    }

                    if (idx != -1)
                    {
                        qtys[idx] += i.Quantity;
                    }
                    else
                    {
                        names.Add(i.ProductName);
                        qtys.Add(i.Quantity);
                    }
                }
            }

            List<ProductStat> stats = new List<ProductStat>();
            for (int i = 0; i < names.Count; i++)
            {
                ProductStat ps = new ProductStat();
                ps.Name = names[i];
                ps.Quantity = qtys[i];
                stats.Add(ps);
            }

            for (int i = 0; i < stats.Count - 1; i++)
            {
                for (int j = i + 1; j < stats.Count; j++)
                {
                    if (stats[i].Quantity < stats[j].Quantity)
                    {
                        ProductStat temp = stats[i];
                        stats[i] = stats[j];
                        stats[j] = temp;
                    }
                }
            }

            List<string> res = new List<string>();
            foreach (var s in stats)
            {
                res.Add(s.Name + ": " + s.Quantity);
            }
            return res;
        }
    }
}