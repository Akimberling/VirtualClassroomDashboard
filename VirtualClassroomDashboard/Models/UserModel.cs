using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
        //model to store data collected from the registration form for an admin user type
    public class UserModel
    {
            //Display names/required error messages + get and set data
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Your first name is required")]
        public string FirstName { get; set; }

            //Display names/required error messages + get and set data
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Your last name is required")]
        public string LastName { get; set; }

            //Display names/not required/if entered data type is a phone number + get and set data
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

            //Display names/required error messages/data type = email(name@name.com) + get and set data
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Your email address is required")]
        public string EmailAddress { get; set; }

            //Display names/compares to the email address entry and notifies user if not matching get and set data
        [Display(Name = "Confirm Email Address")]
        [Compare("EmailAddress", ErrorMessage ="Confirm email address must match your email address")]
        public string ConfirmEmail { get; set; }

            //Display names/required error messages + get and set data
        [Display(Name = "School Name")]
        [Required(ErrorMessage = "Your school name is required")]
        public string SchoolName { get; set; }

            //Display names/required error messages + get and set data
        [Display(Name = "School Level")]
        [Required(ErrorMessage = "Your school level is required")]
        public string SchoolLevel { get; set; }

            //Display names/required error messages + get and set data
        [Display(Name = "School City")]
        [Required(ErrorMessage = "Your school city is required")]
        public string SchoolCity { get; set; }

            //Display names/required error messages/string length should be 2 like CA + get and set data
        [Display(Name = "School State")]
        [StringLength(2)]
        [MinLength(2, ErrorMessage = "Must be 2 letters.")]
        [Required(ErrorMessage = "Your school state is required")]
        public string SchoolState { get; set; }

    }
}
