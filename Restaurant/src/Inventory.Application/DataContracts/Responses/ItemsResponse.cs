﻿using Inventory.Application.DataContracts.Data;

namespace Inventory.Application.DataContracts.Responses
{
    public class ItemsResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
