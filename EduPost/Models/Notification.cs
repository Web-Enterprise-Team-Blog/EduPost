using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("notice_id")]
        public int Id { get; set; }
        [Column("to_user_id")]
        public int UserId { get; set; }
        [Column("message")]
        public string? Message { get; set; }
        [Column("time")]
        public DateTime Timestamp { get; set; }
        [Column("isRead?")]
        public bool IsRead { get; set; }
    }

}
