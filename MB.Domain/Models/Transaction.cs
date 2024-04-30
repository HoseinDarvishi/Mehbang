namespace MB.Domain.Models
{
    public class Transaction
    {
        #region ' Ctor '
        private Transaction() { }

        public Transaction(
            int personId,
            DateTime transactionDate,
            long price)
        {
            PersonId = personId;
            TransactionDate = transactionDate;
            Price = price;
        }
        #endregion

        public long TransactionId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public long Price { get; private set; }

        #region ' Relations '
        public Person Person { get; set; }
        #endregion
    }
}
