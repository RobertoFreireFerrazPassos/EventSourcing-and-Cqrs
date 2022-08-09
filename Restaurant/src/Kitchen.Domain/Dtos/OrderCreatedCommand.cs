namespace Kitchen.Domain.Dtos
{
    public class OrderCreatedCommand
    {
        public int Table { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public OrderCreatedCommand(int table, IEnumerable<Item> item)
        {
            Table = table;
            Items = item;
        }        
    }
}
