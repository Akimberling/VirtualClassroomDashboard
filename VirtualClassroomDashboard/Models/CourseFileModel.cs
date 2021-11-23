using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class CourseFileModel
    {
        //generated in DB
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FIlePath { get; set; }
        public string FileSubject { get; set; }
        public string FileDesc { get; set; }
        public int CourseID { get; set; }
        //user ID
        public int UserID { get; set; }
    }
}
