using System.ComponentModel.DataAnnotations;

namespace MB.Contracts.DTOs
{
    public class PeriodDateDto
    {
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Start_Date { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string End_Date { get; set; }
    }
}
