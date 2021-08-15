using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
    public class excelParseModel
    {
        public int UserID { get; set; }
        public int SchoolID { get; set; }
        public string Salt { get; set; }
        [Display(Name = "User Type")]
        [Required(ErrorMessage = "You must enter a valid user type")]
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
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Your email address is required")]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a - zA - Z0 - 9\s_\\.\-:])+(.xls|.xlsx)$", ErrorMessage = "Only CSV files allowed.")]
        public string Upload { get; set; }
    }
}
