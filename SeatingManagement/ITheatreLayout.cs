using System.Collections.Generic;

namespace SeatingManagement
{
    public interface ITheatreLayout
    {
        IList<SeatRow> Rows { get; }

        void FulFillRequest(ITicketRequest ticketRequest);
    }
}