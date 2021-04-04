using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Entity
    {
		public int Id { get; set; }
		public string CreatedByUserId { get; set; }
		public string UpdatedByUserId { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }
		public Boolean IsActive { get; set; }
	}
}
