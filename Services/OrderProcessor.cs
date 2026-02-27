using System.Collections.Generic;
using SieMarket.Models;

namespace SieMarket.Services
{
    public class OrderProcessor
    {
        public decimal GetFinalPrice(Order order)
        {
            decimal total = order.TotalAmount;
            if (total > 500)
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
                    if (t.Name == o.CustomerOrder.Name)
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
                    ct.Name = o.CustomerOrder.Name;
                    ct.Amount = price;
                    ct.Email = o.CustomerOrder.Email;
                    ct.Phone = o.CustomerOrder.Phone;
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

            for (int i = 0; i < names.Count - 1; i++)
            {
                for (int j = i + 1; j < names.Count; j++)
                {
                    if (qtys[i] < qtys[j])
                    {
                        int tempQty = qtys[i];
                        qtys[i] = qtys[j];
                        qtys[j] = tempQty;

                        string tempName = names[i];
                        names[i] = names[j];
                        names[j] = tempName;
                    }
                }
            }

            List<string> res = new List<string>();
            for (int i = 0; i < names.Count; i++)
            {
                res.Add(names[i] + ": " + qtys[i]);
            }
            return res;
        }
    }
}