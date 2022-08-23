using MyFirstApp_Asp_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstApp_Asp_Mvc.Services.Data
{
    internal class MovieDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // GET: Movies
        public List<FilmModel> FetchAll()
        {
            List<FilmModel> films = new List<FilmModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlquery = "select Id,name,year from dbo.Movies";
                SqlCommand command = new SqlCommand(sqlquery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FilmModel filmModel = new FilmModel();
                        filmModel.Id = reader.GetInt32(0);
                        filmModel.Name = reader.GetString(1);
                        filmModel.Year = reader.GetInt32(2);                      

                        films.Add(filmModel);
                    }
                }
            }

            return films;
        }

        public FilmModel FetchOne(int Id)
        {
          

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlquery = "select * from dbo.Movies where Id=@id";
                SqlCommand command = new SqlCommand(sqlquery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                FilmModel filmModel1 = new FilmModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                     
                        filmModel1.Id = reader.GetInt32(0);
                        filmModel1.Name = reader.GetString(1);
                        filmModel1.Year = reader.GetInt32(2);
                        filmModel1.Storyline = reader.GetString(3);

                      
                    }
                }
                return filmModel1;
            }

            
        }

        public int CreateOrUpdate(FilmModel filmModel)
        {
            string sqlQuery = "";
            if (filmModel.Id <= 0)
            {
                sqlQuery= "INSERT INTO dbo.Movies VALUES(@name,@year,@storyline)";
            }
            else
            {
                sqlQuery = "UPDATE dbo.Movies SET name=@name,year=@year,storyline=@storyline where Id=@Id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = filmModel.Id;
                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 200).Value = filmModel.Name;
                command.Parameters.Add("@year", System.Data.SqlDbType.Int).Value = filmModel.Year;
                command.Parameters.Add("@storyline", System.Data.SqlDbType.VarChar, 2000).Value = filmModel.Storyline;
                connection.Open();

                int newId = command.ExecuteNonQuery();

                FilmModel filmModel1 = new FilmModel();


                return newId;
            }


        }
        internal int Delete(int id)
        {
            string sqlQuery = "Delete from dbo.Movies where Id=@id";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
               
                connection.Open();

                int deleteId = command.ExecuteNonQuery();

                FilmModel filmModel1 = new FilmModel();


                return deleteId;
            }


        }
        internal List<FilmModel> SearchForName(string searchPhrase)
        {
            List<FilmModel> returnlist = new List<FilmModel>();

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Movies WHERE name LIKE @searchForMe";


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. Add it to the list to return.
                        FilmModel films = new FilmModel();
                        films.Id = reader.GetInt32(0);
                        films.Name = reader.GetString(1);
                        films.Year = reader.GetInt32(2);
                        films.Storyline = reader.GetString(3);

                        returnlist.Add(films);
                    }
                }
                return returnlist;
            }

        }
    }
}