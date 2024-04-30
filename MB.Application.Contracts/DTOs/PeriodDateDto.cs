using System.ComponentModel.DataAnnotations;

namespace MB.Contracts.DTOs
{
    public class PeriodDateDto
    {
        [Required]
        [Length(10,10)]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[01])$\r\n")]
        public string Start_Date { get; set; }

        [Required]
        [Length(10,10)]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[01])$\r\n")]
        public string End_Date { get; set; }
    }

    public class PeriodDateTimeDto
    {
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
    }
}
