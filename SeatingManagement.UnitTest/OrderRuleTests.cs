using NUnit.Framework;
using SeatingManagement.OrderRule;
using System.Collections.Generic;

namespace SeatingManagement.UnitTest
{
    public class OrderRuleTests
    {
        [Test]
        public void TheatreCannotHostOrderRuleTest()
        {
            var rule = OrderRuleFactory.Create<TheatreCanHandlePartyOrderRule>();
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Theatre.Instance.ParseLayout(layout);
            var ticketRequest = new TicketRequest { PartyName = "Test1", TicketCount = 50 };
            Assert.DoesNotThrow(() => rule.Validate(Theatre.Instance.Layout, ticketRequest));
        }

        [Test]
        public void PartySitInSingleRowOrderRuleTest()
        {
            var rule = OrderRuleFactory.Create<TheatreCanHandlePartyOrderRule>();
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Theatre.Instance.ParseLayout(layout);
            var ticketRequest = new TicketRequest { PartyName = "Test1", TicketCount = 9 };
            Assert.DoesNotThrow(() => rule.Validate(Theatre.Instance.Layout, ticketRequest));
        }
    }
}
