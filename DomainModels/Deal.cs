using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Deal
    {
        public int ID { get; set; }

        public string GUID { get; set; } = string.Empty;

        public int CustomerID { get; set; }

        public bool IsDeleted { get; set; }

        public int VehicleId { get; set; }
    }
}
