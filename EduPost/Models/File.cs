using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("file_id")]
        public int? FileId { get; set; }

        [Required]
        [Column("file_name")]
        public string? FileName { get; set; }

        [Required]
        [Column("file_data")]
        public byte[]? FileData { get; set; }

        [Required]
        [Column("file_content_type")]
        public string? FileContentType { get; set; }

        public int? ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public Article? Article { get; set; }
    }
}