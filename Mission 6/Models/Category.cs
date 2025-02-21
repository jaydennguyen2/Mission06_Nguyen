using System.ComponentModel.DataAnnotations;

namespace Mission_6.Models
{
    public class Category
    {
        //primary key for category table
        [Key]
        public int? CategoryId { get; set; }

        // Name of the category
        public string? CategoryName { get; set; }
    }
}
