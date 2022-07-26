﻿using Kitchen.Application.Commands;
using Kitchen.Domain.Dtos;
using Kitchen.Domain.Services;
using MediatR;

namespace Kitchen.Application.Handlers
{
    public class ReserveOrderHandler : IRequestHandler<ReserveOrderCommand, bool>
    {
        private readonly IOrderService _orderService;
        public ReserveOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<bool> Handle(ReserveOrderCommand command, CancellationToken cancellationToken)
        {
            var orderReservedCommand = new OrderReservedCommand(command.OrderId);
            return await _orderService.ReserveOrder(orderReservedCommand);
        }
    }
}
