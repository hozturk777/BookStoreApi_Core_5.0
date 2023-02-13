using System.ComponentModel.DataAnnotations;

namespace WebApiBookStore.Entities
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
