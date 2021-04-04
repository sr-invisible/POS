using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class RoleBaseMenuPermission : Entity
    {
		[ForeignKey("ApplicationRole")]
		public string RoleId { get; set; }

		[ForeignKey("NavigationMenu")]
		public int AsideId { get; set; }

		public Aside Aside { get; set; }
	}
}
