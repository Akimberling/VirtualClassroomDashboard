using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class UserAssignmentModel
    {
        public int AssignID { get; set; }
        public int UserID { get; set; }
        public string UserAssignFile { get; set; }
        public int UserAssignGrade { get; set; }
    }
}
