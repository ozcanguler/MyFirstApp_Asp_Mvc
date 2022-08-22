using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstApp_Asp_Mvc.Models
{
    public class FilmModel
    {
        public FilmModel(int id, string name, int year, string storyline)
        {
            Id = id;
            Name = name;
            Year = year;
            Storyline = storyline;
        }
        public FilmModel()
        {
            Id =-1;
            Name = "Nothing";
            Year =-1;
            Storyline = "Nothing yet";
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Storyline { get; set; }
    }
}