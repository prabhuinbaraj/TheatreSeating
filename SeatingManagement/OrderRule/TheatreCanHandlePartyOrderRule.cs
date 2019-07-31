using System.Linq;

namespace SeatingManagement
{
    public class TheatreCanHandlePartyOrderRule : IOrderRule
    {
        public bool Validate(ITheatreLayout theatreLayout, ITicketRequest ticketRequest)
        {
            var totalSeatVacant = theatreLayout.Rows.Sum(row => row.TotalVacant);
            if(totalSeatVacant < ticketRequest.TicketCount)
            {
                throw new RuleValidationException(TheatreCannotHostParty);
            }
            return true;
        }

        private const string TheatreCannotHostParty = "Sorry, we can't handle your party.";
    }
}
