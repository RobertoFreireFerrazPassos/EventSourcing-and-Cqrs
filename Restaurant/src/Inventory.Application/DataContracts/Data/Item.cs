namespace Inventory.Application.DataContracts.Data
{    
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ItemUnit Unit { get; set; }
    }
}
