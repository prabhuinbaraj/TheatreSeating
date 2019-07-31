using SeatingManagement.OrderRule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeatingManagement
{
    /// <summary>
    /// Class reprsents the theatre.
    /// </summary>
    public sealed class Theatre : ITheatre
    {
        private Theatre()
        {
            _orderRules.Add(OrderRuleFactory.Create<TheatreCanHandlePartyOrderRule>());
            _orderRules.Add(OrderRuleFactory.Create<PartySitInSingleRowOrderRule>());
        }
        public ITheatreLayout Layout { get; } = new TheatreLayout();
        public static Theatre Instance { get { return _lazyInstance.Value; } }

        /// <summary>
        /// Parse the layout.
        /// </summary>
        /// <param name="layout"></param>
        public void ParseLayout(IList<string> layout)
        {
            var rowCount = 1;
            foreach (var row in layout)
            {
                var sections = row.Split(' ');
                if (!sections.All(section => int.TryParse(section, out int output)))
                {
                    throw new ArgumentNullException("Invalid section!");
                }
                var seatRow = new SeatRow(rowCount);
                var sectionCount = 1;
                foreach (var section in sections)
                {
                    seatRow.Sections.Add(new RowSection(sectionCount, int.Parse(section)));
                    sectionCount++;
                }
                Layout.Rows.Add(seatRow);
                rowCount++;
            }
        }

        /// <summary>
        /// Process the ticket request
        /// </summary>
        /// <param name="patronMail"></param>
        public void ProcessTicketRequests(PatronMail patronMail)
        {
            foreach (var ticketRequest in patronMail.TicketRequests)
            {
                try
                {
                    // Validate all the rules
                    ApplyRule(ticketRequest);

                    // Fulfill the request
                    Layout.FulFillRequest(ticketRequest);
                }
                catch (RuleValidationException ex)
                {
                    Console.WriteLine($"{ticketRequest.PartyName} {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Apply all the rules on the ticket request 
        /// </summary>
        /// <param name="ticketRequest"></param>
        public void ApplyRule(ITicketRequest ticketRequest)
        {
            // Validate all the rules
            foreach (var orderRule in _orderRules)
            {
                orderRule.Validate(Layout, ticketRequest);
            }
        }

        private static readonly Lazy<Theatre> _lazyInstance = new Lazy<Theatre>(() => new Theatre());
        private static readonly IList<IOrderRule> _orderRules = new List<IOrderRule>();
    }
}
