using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blockbuster.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        [Display (Name = "Number In Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }


        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        public Genre Genre { get; set; }
        
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

    }
}