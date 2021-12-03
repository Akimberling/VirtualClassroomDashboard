
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
        //model to store data collected from the registration form for an admin user type
    public class CourseUpdateModel
    {


        //Display names/required error messages + get and set data
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        //Display names/required error messages + get and set data
        [Display(Name = "Course Section")]
        [Required(ErrorMessage = "Course Section is required")]
        public string CourseSection { get; set; }

    }
}
