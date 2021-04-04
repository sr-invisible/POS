using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        // End :: Custom fields

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Status { get; set; }
    }

    public class RoleViewModel
    {
        public string Id { get; set; }

        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Role Name is Required")]
        [Display(Name = "Role Name")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}