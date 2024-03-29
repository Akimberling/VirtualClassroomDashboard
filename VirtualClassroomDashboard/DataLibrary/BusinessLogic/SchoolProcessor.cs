﻿using VirtualClassroomDashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualClassroomDashboard.DataAccess;

namespace VirtualClassroomDashboard.BusinessLogic
{
    public static class SchoolProcessor
    {
        public static int CreateSchool(string schoolName, string schoolLevel, string schoolCity, string schoolState)
        {
            SchoolModelData data = new SchoolModelData
            {
                SchoolID = 0,
                SchoolName = schoolName,
                SchoolLevel = schoolLevel,
                SchoolCity = schoolCity,
                SchoolState = schoolState
            };

            string sql = @"INSERT INTO dbo.SCHOOL (SchoolID, SchoolName, SchoolLevel, SchoolCity, SchoolState) VALUES (@SchoolID, @SchoolName, @SchoolLevel, @SchoolCity, @SchoolState);";

            return sqlDataAccess.SaveData(sql, data);

        }
        public static List<int> CheckForDuplicates(string schoolName, string schoolLevel, string schoolCity, string schoolState)
        {
            string sql = "SELECT COUNT(*) FROM dbo.SCHOOL WHERE SchoolName = \'" + schoolName + "\' AND SchoolLevel = \'" + schoolLevel + "\' AND SchoolCity = \'" + schoolCity + "\' AND schoolState = \'" + schoolState + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        public static List<int> GetSchoolID(string schoolName)
        {
            
            string sql = "SELECT SchoolID FROM dbo.SCHOOL WHERE SchoolName = \'" + schoolName + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
        public static List<int> GetSchoolInfo(int schoolID)
        {

            string sql = "SELECT * FROM dbo.SCHOOL WHERE SchoolID = \'" + schoolID + "\';";

            return sqlDataAccess.LoadData<int>(sql);
        }
    }
}
