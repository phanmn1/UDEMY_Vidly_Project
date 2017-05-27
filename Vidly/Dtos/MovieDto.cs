using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }


        //public Genre Genre { get; set; }

        [Required]
        //[Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Range(1, 20)]
        //[Display(Name = "Number in Stock")]
        [Required]
        public byte? NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }

        //[Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}