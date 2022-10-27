namespace CafeForDevs.Models
{
    public class OrderPositionModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public uint Quantity { get; set; }

        public decimal Sum => Price * Quantity;
    }
}
