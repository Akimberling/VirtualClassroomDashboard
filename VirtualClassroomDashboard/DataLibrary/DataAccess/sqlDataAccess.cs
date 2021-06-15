using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace VirtualClassroomDashboard.DataAccess
{

    public static class sqlDataAccess
    {
            //Get the connection string and return it 
        public static string GetConnectionString()
        {
            return "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VirtualClassroomDashboard_dbms; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
        }
            //return information collected from database from the exected sql statement that was pased to this static method
            //info gets loaded into list
        public static List<T> LoadData<T>(string sql)
        {
            using(IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }
        //save the data to database and return the rows effected
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
