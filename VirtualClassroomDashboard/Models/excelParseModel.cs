using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
    public class excelParseModel
    {
        public int UserID { get; set; }
        public int SchoolID { get; set; }
        public string Salt { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a - zA - Z0 - 9\s_\\.\-:])+(.xls|.xlsx)$", ErrorMessage = "Only CSV files allowed.")]
        public string Upload { get; set; }
    }
}
