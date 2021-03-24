using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public interface IDataSource
    {
        IEnumerable<Order> Data { get; }
    }

    public class DataSource : IDataSource
    {
        private List<Order> data;
        private readonly int dataCount = 144; 
        public IEnumerable<Order> Data { get => data; }
        public DataSource()
        {
            data = new List<Order>();
            Random rand = new Random();
            var startNumber = rand.Next(1, 100000);
            for (var i = 0; i < dataCount; i++)
            {
                data.Add(new Order()
                {
                    Id = i,
                    Number = startNumber + i,
                    Category = rand.Next(1, 4),
                    Name = $"Order {i + 1}",
                    Price = (float)Math.Round(rand.NextDouble() * 100, 2)
                });
            }
        }
    }
}
