namespace Kitchen.Domain.Dtos
{
    public class OrderReservedCommand
    {
        public int Table { get; set; }

        public OrderReservedCommand(int table)
        {
            Table = table;
        }
    }
}
