namespace TestingPrograms.AutoFixture.Tests.TestingClasses
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Customer.CustomerName}";
        }
    }

    public class OrderItem
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

    public class Customer
    {
        public string CustomerName { get; set; } = string.Empty;
    }
}