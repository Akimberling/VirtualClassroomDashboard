using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
    public class CourseFileModel
    {
        //generated in DB
        public int FileID { get; set; }
        [Display(Name = "Select File")]
        [Required(ErrorMessage = "Selecting a file is required")]
        public string FileName { get; set; }
        public string FIlePath { get; set; }
        [Display(Name = "File Subject")]
        [Required(ErrorMessage = "The File Subject is required")]
        public string FileSubject { get; set; }
        [Display(Name = "File Description")]
        [Required(ErrorMessage = "File Description is required")]
        public string FileDesc { get; set; }
        public int CourseID { get; set; }
        //user ID
        public int UserID { get; set; }
    }
}
