using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Content
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ContentImage { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
