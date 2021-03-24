using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Category { get; set; }
    }
}
