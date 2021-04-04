using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class AppUser 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Phone { get; set; }
		public bool IsActive { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }
		public string Status { get; set; }
	}
}
