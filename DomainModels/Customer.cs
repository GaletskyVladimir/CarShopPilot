using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Customer
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int StoreID { get; set; }

        public string PrimaryFirstName { get; set; } = string.Empty;

        public string PrimaryLastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CellPhone { get; set; } = string.Empty;
    }
}
