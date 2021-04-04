using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.RoleBaseMenuPermission
{
    public class RoleBaseMenuPermissionViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "Role must be selected.")]
        [Display(Name = "Role")]
        public string RoleId { get; set; }

        [Display(Name = "Aside")]
        public int AsideId { get; set; }
    }
}
