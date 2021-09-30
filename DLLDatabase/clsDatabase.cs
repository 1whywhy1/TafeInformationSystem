using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLDatabase
{
    public class clsDatabase
    {
        public static SqlConnection objConnection;//static variables
        public static SqlCommand objCommand;//static variables

        public static SqlConnection ConnectToDatabase()
        {
            String machineName = Environment.MachineName;
            string connectionString = "server=" + machineName + ";database=tafe;trusted_Connection=yes";
            try
            {
                objConnection = new SqlConnection(connectionString);//connecting to the database server
                objConnection.Open();//opening the connection
                return objConnection;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public static SqlDataReader ExecuteQuery(string strSql)
        {
            try
            {
                ConnectToDatabase();//calling method within a method
                objCommand = new SqlCommand(strSql, objConnection);
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    return objDataReader;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public static void ExecuteNonQuery(string strSql)
        {
            try
            {
                ConnectToDatabase();
                objCommand = new SqlCommand(strSql, objConnection);
                objCommand.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new ArgumentNullException("This course teacher already exists");

                }
                else
                if (ex.Number == 547)
                {
                    if (ex.Message.Contains("teacher_course_fk"))
                    {
                        throw new ArgumentNullException("The teacher does not exist");
                    }
                    else
                    if (ex.Message.Contains("course_teacher_fk"))
                    {
                        throw new ArgumentNullException("The course does not exist");
                    }
                }
                else
                {
                    throw new ArgumentNullException(ex.Message);
                }
            }

        }

        public static DataTable CreateDataTable(string tablename)
        {
            try
            {
                ConnectToDatabase();
                string strSql = "select * from " + tablename;
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(strSql, objConnection);//using sqldataadapter constructor
                DataTable objDataTable = new DataTable();//default constructor of datatable class
                objDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}

