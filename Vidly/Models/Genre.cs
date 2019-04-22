using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 0)]
        public string Name { get; set; }
    }
}