using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Models
{
    public class OptionsModel
    {
        public int OptionID { get; set; }
        public string Options { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
    }
}
