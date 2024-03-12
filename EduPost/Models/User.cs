using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int? Id { get; set; }

        [Required]
        [Column("user_name")]
        public string? UserName { get; set; }

        [Required]
        [Column("faculty_id")]
        public int? FacultyId { get; set; }

        [Required]
        [Column("role_id")]
        public int? RoleId { get; set; }
    }
}