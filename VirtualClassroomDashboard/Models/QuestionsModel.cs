using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class QuestionsModel
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string QuestionImage { get; set; }
        public int QuestionType { get; set; }
        public int AssessID { get; set; }
    }
}
