using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Deal
    {
        public Deal()
        {

        }

        public Deal(int dealId)
        {
            this.ID = dealId;
        }

        public int ID { get; }

        public int UserId { get; set; }

        public int CustomerID { get; set; }

        public int VehicleId { get; set; }

        public DealStatus DealStatus { get; set; }

        public bool IsDelivered { get; set; } = false;
    }

    public enum DealStatus
    {
        Engaged = 1,
        Pending = 2,
        Payed = 3,
        Delivered = 4
    }
}
