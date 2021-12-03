using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualClassroomDashboard.Models
{
    public class AssessmentsModel
    {
        public int AssessID { get; set; }
        public string AssessName { get; set; }
        public DateTime AssessStartDate { get; set; }
        public DateTime AssessEndSate { get; set; }
        public string TimeLimit { get; set; }
        public int AssessPoints { get; set; }
        public string AssessType { get; set; }
        public int CourseID { get; set; }
        public int FileID { get; set; }
    }
}
