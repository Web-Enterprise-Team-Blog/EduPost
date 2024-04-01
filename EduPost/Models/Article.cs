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

        [Column("article_faculty")]
        public string? Faculty { get; set; }

        [Column("user_id")]
        public int? UserID { get; set; }

        [Column("deadline")]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column("status_id")]
        public int? StatusId { get; set; }

        public bool AgreeToTerms { get; set; }

        public bool Public { get; set; }

        public ICollection<File>? Files { get; set; }
    }
}