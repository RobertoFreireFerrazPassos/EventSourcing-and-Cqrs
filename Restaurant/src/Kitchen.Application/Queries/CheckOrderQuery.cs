using Kitchen.Application.DataContracts.Responses;
using MediatR;

namespace Kitchen.Application.Queries
{
    public class CheckOrderQuery : IRequest<OrderResponse>
    {
        public int Table { get; set; }

        public CheckOrderQuery(int table)
        {
            Table = table;
        }
    }
}
