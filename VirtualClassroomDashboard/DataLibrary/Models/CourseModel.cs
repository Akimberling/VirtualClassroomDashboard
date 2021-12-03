using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.DataLibrary.Models
{
    public class CourseModelData
    {
        //generated in DB
        public int CourseID { get; set; }
        //School of the admin 
        public int SchoolID { get; set; }
        //Teacher ID
        public int UserID { get; set; }
        public string CourseName { get; set; }
        public string CourseSection { get; set; }
        public string CourseNumber { get; set; }
        public string ClassNum { get; set; }
    }
}
