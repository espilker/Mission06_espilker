using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_espilker.Models
{
    public class MovieModel
    {
        // Model for the Movie database
        [Key]
        [Required]
        public int MovieId { get; set; }

        //Make these coloumns required
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ushort Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }


        public bool Edited { get; set; }
        public string LentTo { get; set; }

        //set a max length for the notes box
        [StringLength(25)]
        public string Notes { get; set; }
    }
}
