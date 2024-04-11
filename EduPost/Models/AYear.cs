using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduPost.Models
{
	public class AYear
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("year_id")]
		public int YearId { get; set; }
		[Column("year_title")]
		[Required]
		public string? YearTitle { get; set; }
		[Column("begin_date")]
		[Required]
		public DateTime BeginDate { get; set; }
		[Column("end_date")]
		[Required]
		public DateTime EndDate { get; set; }
	}
}
