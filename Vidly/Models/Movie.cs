using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }

    // /movies/random
}