using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class GradeFormatModel
    {
        public int GradeFormatID { get; set; }
        public string GradeFSection { get; set; }
        public string GradeFPercent { get; set; }
        public int CourseID { get; set; }
    }
}
