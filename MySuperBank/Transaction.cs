namespace MySuperBank
{
    public class Transaction
    {
        public int Amount { get; init; }
        public string Notes { get; init; }

        public Transaction()
        {

        }

        public Transaction(int amount, string note)
        {
            Amount = amount;
            Notes = note;
        }
    }
}
