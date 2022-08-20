using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyFirstApp_Asp_Mvc.Models;

namespace MyFirstApp_Asp_Mvc.Services.Data
{
    public class SecurityDAO
    {
        //connect database test database right click properties connection string path
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {
            bool success = false;
            string queryString = "select*from dbo.Users where username=@userName and password=@Password";

            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@userName", System.Data.SqlDbType.NVarChar, 50).Value=user.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value=user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}