using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class Article
    {
        public Article()
        {
            Files = new List<File>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("article_id")]
        public int? ArticleId { get; set; }

        [Column("article_name")]
        [Required]
        public string? ArticleTitle { get; set; }

        [Column("user_id")]
        //[Required]
        public int? UserID { get; set; }

        [Column("deadline")]
        //[Required]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column("status_id")]
        //[Required]
        public int? StatusId { get; set; }

        public ICollection<File>? Files { get; set; }
    }
}