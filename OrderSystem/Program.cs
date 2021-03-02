using System;
using System.Globalization;
using OrderSystem.Entities;
using OrderSystem.Entities.Enums;


namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();

            Console.Write("E-mail: ");
            string clientEmail = Console.ReadLine();

            Console.Write("Birth date (DD/MM/AAAA): ");
            DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, clientBirthDate);

            Console.WriteLine("Enter order data");

            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int numberOfItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfItems; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, productPrice);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderitem = new OrderItem(quantity, productPrice, product);

                order.AddItem(orderitem);
            }

            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
