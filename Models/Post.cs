using System.ComponentModel.DataAnnotations;

namespace BEPortal.Models
{
    public class Post
    {
        public int id { get; set; }
        [Required]
        public string post { get; set; }
        [Required]
        public string assunto { get; set; }
        [Required]
        public string conteudo { get; set; }
        [Required]
        public DateTime data { get; set; }
    }
}
