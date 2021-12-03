using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassroomDashboard.Classes
{
    public class setDiscussionClass
    {
        //Discussion id
        private static int DID;

        public static void setDiscussData(int discussID)
        {

            DID = discussID;
        }
        public static int geDiscussData()
        {
            return DID;
        }
    }
}

