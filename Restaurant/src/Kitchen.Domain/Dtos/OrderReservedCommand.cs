namespace Kitchen.Domain.Dtos
{
    public class OrderReservedCommand
    {
        public Guid OrderId { get; set; }

        public OrderReservedCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
