using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace blockbuster.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }
    }
}