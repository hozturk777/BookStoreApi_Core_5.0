using System.ComponentModel.DataAnnotations;

namespace WebApiBookStore.Entities
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int DateOfBirth { get; set; }
    }
}
