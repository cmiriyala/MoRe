using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoRe.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genres Genres { get; set; }
        
        [Display(Name = "Genre")]
        public byte GenresId { get; set; }
        
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? AddedDate { get; set; }
        [Required]
        [Display(Name = "Number in stock")]
        public int NumberinStock { get; set; }
    }

}