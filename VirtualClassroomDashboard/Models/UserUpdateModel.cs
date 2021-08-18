using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace VirtualClassroomDashboard.Models
{
    public class UserUpdateModel
    {

        //Display names/not required/if entered data type is a phone number + get and set data
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Your phone number must be a minimum length of 10.")]
        public string PhoneNumber { get; set; }

       

        //Display names/required error messages/password
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Your password must be a minimum length of 10.")]
        public string Password { get; set; }

    }
}
