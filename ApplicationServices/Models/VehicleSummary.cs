using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models
{
    public class VehicleSummary
    {
        [Required(ErrorMessage = "No Store Id")]
        public int StoreID { get; set; }

        [Required(ErrorMessage = "Please, Enter email")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please, Enter email")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please, Enter email")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please, Enter email")]
        public double Price { get; set; }
    }
}
