using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,99,ErrorMessage ="Order number range should be 1 - 99.")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
