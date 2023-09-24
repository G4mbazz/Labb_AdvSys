using System.ComponentModel.DataAnnotations;

namespace ModelsLib.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public int PublishingYear { get; set; }
        public string Genre { get; set; }
        public int Stock { get; set; }


    }
}
