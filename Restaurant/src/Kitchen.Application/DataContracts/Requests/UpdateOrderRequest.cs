using Kitchen.Domain.Dtos;

namespace Kitchen.Application.DataContracts.Requests
{
    public class UpdateOrderRequest
    {
        public int Table { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
