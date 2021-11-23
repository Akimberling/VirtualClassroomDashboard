using VirtualClassroomDashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroomDashboard.DataAccess;
using VirtualClassroomDashboard.DataLibrary.Models;

namespace VirtualClassroomDashboard.DataLibrary.BusinessLogic
{
    public class FileProcessor
    {
        public static int CreateFile(string fname, string fpath, string fsubject, string fdesc, int uid, int cid)
        {
            FileModelData data = new FileModelData
            {
                FileID = 0,
                FileName = fname,
                FIlePath = fpath,
                FileSubject = fsubject,
                FileDesc = fdesc,
                CourseID = cid,
                UserID = uid
                
            };

            string sql = @"INSERT INTO dbo.COURSE_FILES (FileID, FileName, FilePath, FileSubject, FileSubject, FileDesc, UserID CourseID) VALUES (@FileID, @FileName, @FIlePath, @FileSubject, @FileDesc, @UserID, @CourseID);";

            return sqlDataAccess.SaveData(sql, data);

        }

        public static List<int> CheckForDuplicates(string fname, int uid, int cid, string fsub)
        {
            string sql = "SELECT COUNT(*) FROM dbo.COURSE_FILES WHERE FileName = \'" + fname + "\' AND FileSubject = \'" + fsub + "\' AND UserID = \'" + uid + "\' AND CourseID = \'" + cid + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        //update the syllabus 
        public static int updateSyllabusFileInfo(string fname, string fpath, int uid, int cid)
        {
            FileModelData data = new FileModelData
            {
                FileName = fname,
                FIlePath = fpath,
                UserID = uid,
                CourseID = cid
            };

           
            string sql = "UPDATE dbo.COURSE_FILES SET FileName = \'" + data.FileName + "\', FilePath = \'" + data.FIlePath + "\', UserID = \'" + data.UserID + "\', CourseID = \'" + data.CourseID + "\';"; ;
            return sqlDataAccess.SaveData(sql, data);
        }
        //remove a file
        public static int deleteCourseFileData(string fname, string fpath, int uid, int cid)
        {
            FileModelData data = new FileModelData
            {
                FileName = fname,
                FIlePath = fpath,
                UserID = uid,
                CourseID = cid
            };

            string sql = "DELETE FROM dbo.COURSE_FILES WHERE FileName = \'" + data.FileName + "\' AND FilePath = \'" + data.FIlePath + "\' AND UserID = \'" + data.UserID + "\' AND CourseID = \'" + data.CourseID + "\';"; ;

            return sqlDataAccess.SaveData(sql, data);
        }
        //retrieve a particular file
        public static List<FileModelData> RetrieveCourseFile(string fsub,string fpath, int uid, int cid)
        {
            FileModelData data = new FileModelData
            {
                FileSubject = fsub,
                FIlePath = fpath,
                UserID = uid,
                CourseID = cid
            };

            string sql = "SELECT * FROM dbo.COURSE_FILES WHERE FileSubject = \'" + data.FileSubject + "\' AND FilePath = \'" + data.FIlePath + "\' AND UserID = \'" + data.UserID + "\' AND CourseID = \'" + data.CourseID + "\';";

            return sqlDataAccess.LoadData<FileModelData>(sql);
        }
        //retrieve all course information
        public static List<FileModelData> RetrieveAllCourseFile(string fname, string fpath, int uid, int cid)
        {
            FileModelData data = new FileModelData
            {
                FileName = fname,
                FIlePath = fpath,
                UserID = uid,
                CourseID = cid
            };

            string sql = "SELECT * FROM dbo.COURSE_FILES WHERE FileName = \'" + data.FileName + "\' AND FilePath = \'" + data.FIlePath + "\' AND UserID = \'" + data.UserID + "\' AND CourseID = \'" + data.CourseID + "\';";

            return sqlDataAccess.LoadData<FileModelData>(sql);
        }
    }
}
