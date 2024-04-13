using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
	public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("comment_id")]
        public int CommentId { get; set; }

        [Column("content")]
        [Required]
        public string? Content { get; set; }

        [Column("article_id")]
        [Required]
        public int? ArticleId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("anonymous")]
        public bool? IsAnon{ get; set; }

        [Column("comment_date")]
        [Required]
        public DateTimeOffset CreatedDate { get; set; }

		[Column("edited")]
		[Required]
		public bool? IsEdited { get; set; }
	}
}
