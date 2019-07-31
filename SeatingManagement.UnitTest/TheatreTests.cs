using NUnit.Framework;
using SeatingManagement;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ParseCorrectLayoutTest()
        {
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Assert.DoesNotThrow(() => Theatre.Instance.ParseLayout(layout));
        }

        [Test]
        public void ParseWrongLayoutTest()
        {
            var layout = new List<string> { "2 3", "3 4 5", "6 7 A" };

            Assert.Throws<ArgumentNullException>(() => Theatre.Instance.ParseLayout(layout));
        }

        [Test]
        public void ApplyOrderRuleTest()
        {
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Theatre.Instance.ParseLayout(layout);
            var ticketRequest = new TicketRequest { PartyName = "Test1", TicketCount = 50 };
            Assert.Throws<RuleValidationException>(() => Theatre.Instance.ApplyRule(ticketRequest));
        }

        [Test]
        public void ApplyOrderRuleCanHostRequestTest()
        {
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Theatre.Instance.ParseLayout(layout);
            var ticketRequest = new TicketRequest { PartyName = "Test1", TicketCount = 3 };
            Assert.DoesNotThrow(() => Theatre.Instance.ApplyRule(ticketRequest));
        }
    }
}