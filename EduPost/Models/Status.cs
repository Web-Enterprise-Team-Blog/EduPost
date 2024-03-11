using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPost.Models
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_id")]
        public int? Status_id { get; set; }

        [Required]
        [Column("statusName")]
        public string? StatusName { get; set; }
    }
}
