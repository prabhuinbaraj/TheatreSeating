namespace SeatingManagement
{
    public interface IOrderRule
    {
        bool Validate(ITheatreLayout theatreLayout, ITicketRequest ticketRequest);
    }
}
