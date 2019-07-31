using System;
using System.Collections.Generic;
using System.Text;

namespace SeatingManagement
{
    public class PatronMail
    {
        public PatronMail(IList<string> requests)
        {
            ParseTicketRequest(requests);
        }
        public IList<ITicketRequest> TicketRequests { get; } = new List<ITicketRequest>();      
        
        private void ParseTicketRequest(IList<string> requests)
        {
            foreach (var request in requests)
            {
                var requestinformation = request.Split(' ');
                if (!requestinformation.Length.Equals(2) || !int.TryParse(requestinformation[1], out int output))
                {
                    throw new ArgumentNullException("Invalid Request!");
                }
                var ticketRequest = new TicketRequest
                {
                    PartyName = requestinformation[0],
                    TicketCount = int.Parse(requestinformation[1])
                };
                TicketRequests.Add(ticketRequest);
            }
        }
    }
}
