using GenericRepositorySample.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GenericRepositorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(typeof(CustomerRepository))
                .AddSingleton(typeof(Repository<>))
                .AddSingleton(typeof(Context))
                .AddSingleton(typeof(UnitOfWork))
                .BuildServiceProvider();

            var context = 
                serviceProvider.GetService<Context>();

            context.Database.EnsureCreated();

            var unitOfWork = 
                serviceProvider.GetService<UnitOfWork>();

            var customer = new Customer
            {
                Name = "John Doe",
                Address = "677 5th Ave, New York, NY 10022, USA",
                Email = "johndoe@email.com"
            };
            unitOfWork.Customers.Add(customer);

            var order = new Order
            {
                Date = DateTime.Now,
                Customer = customer
            };
            unitOfWork.Orders.Add(order);

            unitOfWork.SaveChanges();

            var count = unitOfWork.Customers.Count();

            Console.WriteLine($"Customers count: {count}");
            Console.Read();
        }
    }
}
