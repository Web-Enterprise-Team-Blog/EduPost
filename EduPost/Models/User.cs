using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int? User_id { get; set; }

        [Required]
        [Column("userName")]
        public string? UserName { get; set; }

        [Required]
        [Column("statusName")]
        public string? StatusName { get; set; }

        [Required]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [Column("password")]
        public string? Password { get; set; }

        [Required]
        [Column("faculty_id")]
        public int? Faculty_id { get; set; }

        [Required]
        [Column("role_id")]
        public int? Role_id { get; set; }
    }
}