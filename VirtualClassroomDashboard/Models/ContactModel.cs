using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
    public class ContactModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Your first name is required")]
        public string fName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Your last name is required")]
        public string lName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Your email is required")]
        public string email { get; set; }

        [Display(Name = "School")]
        public string schoolName { get; set; }

        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Your comments are required")]
        public string comments { get; set; }
    }
}
