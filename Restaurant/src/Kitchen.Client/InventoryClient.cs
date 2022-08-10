using Kitchen.Client.Base;
using Kitchen.Domain.Clients;
using Kitchen.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Kitchen.Client
{
    public class QuantityItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }

    public class ItemsRequest
    {
        public IEnumerable<QuantityItem> Items { get; set; }
    }

    public class InventoryClient : ClientBase, IInventoryClient
    {
        private readonly string _uriBase = "http://localhost:3000";
        public InventoryClient(
            HttpClient httpClient,
            ILogger<ClientBase> logger) : base(httpClient, logger) {}

        public async Task<bool> GetItems(IEnumerable<ItemEntity> items)
        {
            var uri = new Uri(_uriBase + "/Use");

            var request = new ItemsRequest()
            {
                Items = items.Select(i => new QuantityItem()
                {
                    Id = i.Id,
                    Quantity = i.Quantity
                })
            };

            return await Post<ItemsRequest, bool>(uri, request);
        }

        public async Task<bool> ReturnItem(IEnumerable<ItemCopiedFromInventoryEntity> items)
        {
            var uri = new Uri(_uriBase + "/Return");

            var request = new ItemsRequest()
            {
                Items = items.Select(i => new QuantityItem()
                {
                    Id = i.Id,
                    Quantity = i.Quantity
                })
            };

            return await Post<ItemsRequest,bool> (uri, request);
        }
    }
}
