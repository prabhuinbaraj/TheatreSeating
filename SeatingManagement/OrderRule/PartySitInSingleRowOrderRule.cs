using System.Linq;

namespace SeatingManagement
{
    public class PartySitInSingleRowOrderRule : IOrderRule
    {
        public bool Validate(ITheatreLayout theatreLayout, ITicketRequest ticketRequest)
        {
            if(!theatreLayout.Rows.Any(
                row => row.Sections.Any(
                    section => section.SeatVacant >= ticketRequest.TicketCount)) &&
                    theatreLayout.Rows.Sum(row => row.TotalVacant) > ticketRequest.TicketCount)
            {
                throw new RuleValidationException(PartyCannotSitInSingleRowFailure);
            }
            return true;
        }

        private const string PartyCannotSitInSingleRowFailure = "Call to split party";
    }
}
