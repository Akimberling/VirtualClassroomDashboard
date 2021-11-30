using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class AssignmentsModel
    {
        public int AssignID { get; set; }
        public string AssignName { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime AsssignDueDate { get; set; }
        public string Description { get; set; }
        public int AssignPoints { get; set; }
        public string AssignType { get; set; }
        public int CourseID { get; set; }
        public int FileID { get; set; }
    }
}
