namespace StoreAPI.DTO
{
    public class OrderUpdateDTO
    {
        public string OrderStatus { get; set; } = null!;
        public DateTime? ShippedDate { get; set; }
    }
}
