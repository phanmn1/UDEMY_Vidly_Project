using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class NewMovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        [Required]
        public byte? NumberInStock { get; set; } 

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        public string Title
        {
            get
            {
                return id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public NewMovieFormViewModel ()
        {
            id = 0;   
        }

        public NewMovieFormViewModel (Movie movie)
        {
            id = movie.id;
            ReleaseDate = movie.ReleaseDate;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}