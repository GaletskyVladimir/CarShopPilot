using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Vehicle
    {
        public int ID { get; }

        public int StoreID { get; set; }

        public int Year { get; set; }

        public string Make { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public double Price { get; set; }
    }
}
