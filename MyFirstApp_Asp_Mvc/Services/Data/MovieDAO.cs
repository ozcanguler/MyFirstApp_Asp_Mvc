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
    }
}