using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyFirstApp_Asp_Mvc.Models;

namespace MyFirstApp_Asp_Mvc.Services.Data
{
    internal class SecurityDAO
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

        public UserModel FetchOne(int Id)
        {


            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Gadgets where Id = @id";
                //associate @id with Id parameter
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                UserModel gadget = new UserModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. Add it to the list to return.

                        gadget.Id = reader.GetInt32(0);
                        gadget.UserName = reader.GetString(1);
                        gadget.Password = reader.GetString(2);
 
                    }
                }
                return gadget;
            }

        }


        public int Create(UserModel userModel)
        {


            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO dbo.Users VALUES(@username,@password)";
                //associate @id with Id parameter
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 1000).Value = userModel.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 1000).Value = userModel.Password;               
                connection.Open();

                int newId = command.ExecuteNonQuery(); //We're not Selecting any database we're doing some inserting

                UserModel user = new UserModel();


                return newId;
            }

        }

    }

   

}