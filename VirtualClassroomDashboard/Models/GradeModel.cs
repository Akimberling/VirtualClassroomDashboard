using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class GradeModel
    {
        public int GradeID { get; set; }
        public int GradePoints { get; set; }
        public string GradePercent { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
    }
}
