using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Store
    {
        public Store()
        {

        }

        public Store(int storeId)
        {
			this.ID = storeId;
        }

		public int ID { get; }

		public string Name { get; set; } = string.Empty;

		public string Address { get; set; } = string.Empty;

		public string City { get; set; } = string.Empty;

		public string State { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Phone { get; set; } = string.Empty;

		public DateTime DateCreated { get; } = DateTime.Now;
	}
}
