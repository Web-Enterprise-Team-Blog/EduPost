﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("feedback_id")]
        public int FeedbackId { get; set; }

        [Column("content")]
        [Required]
        public string? Content { get; set; }

        [Column("article_id")]
        [Required]
        public int? ArticleId { get; set; }

        [Column("user_id")]
        [Required]
        public int? UserId { get; set; } 

        [Column("feedback_date")]
        [Required]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
