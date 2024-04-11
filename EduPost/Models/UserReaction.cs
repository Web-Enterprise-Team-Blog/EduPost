using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
	public class UserReaction
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserReactionId { get; set; }
		[Column("user_id")]
		public int UserId { get; set; }
		[Column("article_id")]
		public int ArticleId { get; set; }
		[Column("reaction_type")]
		public bool ReactionType { get; set; }
	}
}
