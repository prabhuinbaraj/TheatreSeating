using System;
using System.Collections.Generic;
using System.Text;

namespace SeatingManagement
{
    public class TicketRequest : ITicketRequest
    {
        public int TicketCount { get; set; }
        public string PartyName { get; set; }
    }
}
