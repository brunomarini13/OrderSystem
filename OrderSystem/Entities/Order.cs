using System;
using System.Collections.Generic;
using System.Text;
using OrderSystem.Entities.Enums;
using System.Globalization;

namespace OrderSystem.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItem> Orders = new List<OrderItem>();

        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            Orders.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Orders.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.Append(Moment);
            sb.AppendLine();
            sb.Append("Order status: ");
            sb.Append(Status);
            sb.AppendLine();
            sb.AppendLine(Client.ToString());
            sb.AppendLine("Order items:");

            foreach (OrderItem order in Orders)
            {
                sb.AppendLine(order.ToString());
            }

            double sum = 0.0;

            sb.Append("Total price: $");

            foreach (OrderItem order in Orders)
            {
                sum += order.SubTotal();
            }

            sb.AppendLine(sum.ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
