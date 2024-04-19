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
        public int ArticleId { get; set; }

        [Column("article_name")]
        [Required]
        public string? ArticleTitle { get; set; }

        [Column("article_faculty")]
        public string? Faculty { get; set; }

        [Column("description")]
        public string? Description { get; set; }
        [Column("image")]
        public byte[]? Image { get; set; }

        [Column("user_id")]
        public int? UserID { get; set; }
        public User? User { get; set; }

        [Column("create_date")]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column("expire_date")]
        public DateTimeOffset? ExpireDate { get; set; }

        [Column("status")]
        public int? StatusId { get; set; }

        public bool AgreeToTerms { get; set; }

        public bool Public { get; set; }
        
        public bool AllowFIleDownload { get; set; } = false;

        public bool IsExpired
        {
            get
            {
                if (ExpireDate.HasValue)
                {
                    return ExpireDate.Value < DateTimeOffset.Now;
                }

                return false;
            }
        }

        public ICollection<File>? Files { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
		public List<UserReaction> UserReactions { get; set; } = new List<UserReaction>();
		public List<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

	}
}