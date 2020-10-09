using DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models
{
    public class DealSummary
    {
        [Required(ErrorMessage = "Please, Enter User Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please, Enter Customer Id")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please, Enter Vehicle")]
        public int VehicleId { get; set; }
    }
}
