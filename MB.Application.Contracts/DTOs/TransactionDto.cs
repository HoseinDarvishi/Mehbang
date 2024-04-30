namespace MB.Contracts.DTOs
{
    public class TransactionDto
    {
        public int PersonId { get; set; }
        public DateTime Date { get; set; }
        public long Price { get; set; }
        public string PersonName { get; set; }
        public string PersonFamily { get; set; }
    }
}