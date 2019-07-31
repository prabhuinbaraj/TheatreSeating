using SeatingManagement.Exception;
using System;
using System.Collections.Generic;

namespace SeatingManagement
{
    internal class TheatreLayout : ITheatreLayout
    {
        public IList<SeatRow> Rows { get; } = new List<SeatRow>();

        /// <summary>
        /// FulFill the request.
        /// </summary>
        /// <param name="ticketRequest"></param>
        public void FulFillRequest(ITicketRequest ticketRequest)
        {
            try
            {
                // Try exact match section
                var matchSection = FindExactMatchSection(ticketRequest);
                if (!matchSection.HasValue)
                {
                    // Try first fit section
                    matchSection = FindFirstMatchSection(ticketRequest);
                }
                if(!matchSection.HasValue)
                {
                    throw new FulFillOrderRequestException(FulFillOrderRequestFailure);
                }
                matchSection.Value.section.SeatVacant = matchSection.Value.section.SeatCount - ticketRequest.TicketCount;
                Console.WriteLine($"{ticketRequest.PartyName} Row {matchSection.Value.row} Section {matchSection.Value.section.SectionId}");
            }
            catch (FulFillOrderRequestException)
            {
                throw;
            }
        }

        private (int row, RowSection section)? FindExactMatchSection(ITicketRequest ticketRequest)
        {
            foreach (var row in Rows)
            {
                foreach (var section in row.Sections)
                {
                    if(section.SeatVacant.Equals(ticketRequest.TicketCount))
                    {
                        return (row.RowId, section);
                    }
                }
            }
            return null;
        }

        private (int row, RowSection section)? FindFirstMatchSection(ITicketRequest ticketRequest)
        {
            foreach (var row in Rows)
            {
                foreach (var section in row.Sections)
                {
                    if (section.SeatVacant > ticketRequest.TicketCount)
                    {
                        return (row.RowId, section);
                    }
                }
            }
            return null;
        }

        private const string FulFillOrderRequestFailure = "Order FulFill request failed!";
    }
}
