using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models
{
    public class StoreSummary
    {
		[Required(ErrorMessage = "Please, Enter Store Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please, Enter Store Address")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please, Enter City")]
		public string City { get; set; }

		[Required(ErrorMessage = "Please, Enter State")]
		public string State { get; set; }

		[Required(ErrorMessage = "Please, Enter Store Email")]
		[EmailAddress(ErrorMessage = "Please, Enter Valid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please, Enter Store Phone")]
		public string Phone { get; set; }
	}
}
