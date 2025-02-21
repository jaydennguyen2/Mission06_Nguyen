using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission_6.Models
{
    public class Movie
    {

        // Primary key for the Movie table
        [Key]
        public int MovieId { get; set; }

        // Foreign key referencing the Category table
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // Required field for the movie title
        [Required]
        public string Title { get; set; }

        // Required field for the movie year. minimum year is 1888
        [Required]
        [Range(1888, int.MaxValue)]
        public int Year { get; set; }

        // Required field for the movie director
        public string? Director { get; set; }

        // Required field for the movie rating
        public string? Rating { get; set; }

        // Required field for edited 
        [Required]
        public bool Edited { get; set; }

        // Required field for lent to
        public string? LentTo { get; set; }

        // Required field for the copied to plex
        [Required]
        public bool CopiedToPlex { get; set; }

        // field for notes. limited characters to 25
        [StringLength(25)]
        public string? Notes { get; set; }

    }
}
