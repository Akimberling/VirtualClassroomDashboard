
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
        //model to store data collected from the registration form for an admin user type
    public class UserModel
    {
            //only for when a user signs in
        public int UserID { get; set; }
        public int SchoolID { get; set; }
        public string Salt { get; set; }
        public string UserType { get; set; }

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
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Your phone number must be a minimum length of 10.")]
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

        //Display names/required error messages/password
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [StringLength(100, MinimumLength =10, ErrorMessage = "Your password must be a minimum length of 10.")]
        [Required(ErrorMessage = "Your password is required")]
        public string Password { get; set; }

        //Display names/compares to the password entry and notifies user if not matching get and set data
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password must match your password")]
        public string ConfirmPassword { get; set; }

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
