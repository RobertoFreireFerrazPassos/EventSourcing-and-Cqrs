﻿using Kitchen.Domain.Events;

namespace Kitchen.Domain.Producers
{
    public interface IOrderEventProducer
    {
        public Task<bool> Publish(StoredEvent storedEvent);
    }
}
