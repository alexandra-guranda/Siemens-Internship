using System.Collections.Generic;
using SieMarket.Models;

namespace SieMarket.Services
{
    public class OrderProcessor
    {
        public decimal GetFinalPrice(Order order)
        {
            decimal total = order.totalAmount;
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
                    if (t.name == o.customerData.name)
                    {
                        found = t;
                        break;
                    }
                }

                if (found != null)
                {
                    found.amount += price;
                }
                else
                {
                    Customer ct = new Customer();
                    ct.name = o.customerData.name;
                    ct.amount = price;
                    ct.email = o.customerData.email;
                    ct.phone = o.customerData.phone;
                    totals.Add(ct);
                }
            }

            decimal max = -1;
            foreach (var t in totals)
            {
                if (t.amount > max)
                {
                    max = t.amount;
                }
            }

            string topNames = "";
            foreach (var t in totals)
            {
                if (t.amount == max)
                {
                    if (topNames == "")
                    {
                        topNames = t.name;
                    }
                    else
                    {
                        topNames = topNames + ", " + t.name;
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
                foreach (var i in o.items)
                {
                    int idx = -1;
                    for (int j = 0; j < names.Count; j++)
                    {
                        if (names[j] == i.productName)
                        {
                            idx = j;
                            break;
                        }
                    }

                    if (idx != -1)
                    {
                        qtys[idx] += i.quantity;
                    }
                    else
                    {
                        names.Add(i.productName);
                        qtys.Add(i.quantity);
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