using System.Collections.Generic;

namespace SeatingManagement
{
    public interface ITheatre
    {
        ITheatreLayout Layout { get; }

        void ParseLayout(IList<string> layout);
        void ProcessTicketRequests(PatronMail patronMail);
        void ApplyRule(ITicketRequest ticketRequest);
    }
}