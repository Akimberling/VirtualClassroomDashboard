using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class AssessmentResultModel
    {
        public int AssessResultID { get; set; }
        public bool IsCorrect { get; set; }
        public string AssessDescription { get; set; }
        public int OptionID { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
    }
}
