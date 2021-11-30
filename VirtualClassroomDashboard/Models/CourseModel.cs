
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
        //model to store data collected from the registration form for an admin user type
    public class CourseModel
    {
        //generated in DB
        public int CourseID { get; set; }
        //School of the admin 
        public int SchoolID { get; set; }
        //Teacher ID
        public int UserID { get; set; }

        //Display names/required error messages + get and set data
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        //Display names/required error messages + get and set data
        [Display(Name = "Course Section")]
        [Required(ErrorMessage = "Course Section is required")]
        public string CourseSection { get; set; }

        //Display names/required error messages + get and set data
        [Display(Name = "Course Number")]
        [Required(ErrorMessage = "Course Number is required")]
        public string CourseNumber { get; set; }

        //Display names/required error messages + get and set data
        [Display(Name = "Class Number")]
        [Required(ErrorMessage = "Class Number is required")]
        public string ClassNum { get; set; }

    }
}
