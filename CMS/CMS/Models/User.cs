namespace CMS.Models
{
    public class User
    {

        public int Id { get; set; }
        public string FullName { get; set; }

        public string Password { get; set; }

        public string UserCode { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<Content>? contents { get; set; }
    }
}
