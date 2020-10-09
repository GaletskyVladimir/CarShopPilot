using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models
{
    public class CustomerSummary
    {
        [Required(ErrorMessage = "Please, Enter User Id")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please, Enter Store Id")]
        public int StoreID { get; set; }

        [Required(ErrorMessage = "Please, Enter PrimaryFirstName")]
        public string PrimaryFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please, Enter PrimaryLastName")]
        public string PrimaryLastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please, Enter Email")]
        [EmailAddress(ErrorMessage = "Please, enter valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please, Enter Phone")]
        public string CellPhone { get; set; } = string.Empty;
    }
}
