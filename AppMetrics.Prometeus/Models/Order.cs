namespace AppMetrics.Prometues.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int UserId { get; set; }

        public string OrderName { get; set; }

    }
}