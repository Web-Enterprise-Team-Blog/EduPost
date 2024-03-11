using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("article_id")]
        public int? Article_id { get; set; }

        [Column("article_name")]
        [Required]
        public string? Article_name { get; set; }

        [Column("user_id")]
        [Required]
        public int? UserID { get; set; }

        [Column("deadline")]
        [Required]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column("status_id")]
        [Required]
        public int? Status_id { get; set; }
    }
}