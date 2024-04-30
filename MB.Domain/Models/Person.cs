namespace MB.Domain.Models
{
    public class Person
    {
        #region ' Ctor '
        private Person() { }

        public Person(
            string name,
            string family)
        {
            Name = name;
            Family = family;
        }
        #endregion

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        #region ' Relations '

        public List<Transaction> Transactions { get; set; }

        #endregion
    }
}