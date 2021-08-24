namespace MySuperBank
{
    public class Transaction
    {
        public int Amount { get; init; } // Using init allows only constructors and initialization code to set properties.
        public string Notes { get; init; }

        public Transaction() // Empty constructor needed for deserialization.
        {

        }

        public Transaction(int amount, string note)
        {
            Amount = amount;
            Notes = note;
        }
    }
}
