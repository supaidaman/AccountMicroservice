namespace AccountMicroservice.Domain
{
    public class Account
    {
        public Account(int id, string name, string description, decimal price, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Balance = price;
            Type = type;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }

    }
}
