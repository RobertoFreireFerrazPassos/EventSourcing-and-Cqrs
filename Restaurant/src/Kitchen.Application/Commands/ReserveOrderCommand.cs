using MediatR;

namespace Kitchen.Application.Commands
{
    public class ReserveOrderCommand : IRequest<bool>
    {
        public int Tableid { get; set; }

        public ReserveOrderCommand(int tableid)
        {
            Tableid = tableid;
        }
    }
}
