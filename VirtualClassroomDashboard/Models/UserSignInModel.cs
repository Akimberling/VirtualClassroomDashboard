
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{ 
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Your email is required to sign in")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Your password is required to sign in")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
