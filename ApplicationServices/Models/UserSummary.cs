using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models
{
    public class UserSummary
    {
        [Required(ErrorMessage = "No Store Id")]
        public int StoreID { get; set; }

        [Required(ErrorMessage = "Please, Enter email")]
        [EmailAddress(ErrorMessage = "Please, enter valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please, Enter first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please, Enter last name")]
        public string LastName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
