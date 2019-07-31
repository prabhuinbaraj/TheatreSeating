namespace SeatingManagement
{
    public interface ITicketRequest
    {
        /// <summary>
        /// Party name
        /// </summary>
        string PartyName { get; set; }

        /// <summary>
        /// Ticket count
        /// </summary>
        int TicketCount { get; set; }
    }
}