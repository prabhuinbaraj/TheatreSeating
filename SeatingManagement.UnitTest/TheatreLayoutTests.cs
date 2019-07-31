using NUnit.Framework;
using SeatingManagement.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeatingManagement.UnitTest
{
    public class TheatreLayoutTests
    {
        [Test]
        public void FulFillOrderRequestTest()
        {
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Theatre.Instance.ParseLayout(layout);
            var ticketRequest = new TicketRequest { PartyName = "Test1", TicketCount = 4 };
            Assert.DoesNotThrow(() => Theatre.Instance.Layout.FulFillRequest(ticketRequest));
        }

        [Test]
        public void FulFillWrongOrderRequestTest()
        {
            var layout = new List<string> { "2 3", "3 4 5", "6 7 8" };

            Theatre.Instance.ParseLayout(layout);
            var ticketRequest = new TicketRequest { PartyName = "Test1", TicketCount = 25 };
            Assert.Throws<FulFillOrderRequestException>(() => Theatre.Instance.Layout.FulFillRequest(ticketRequest));
        }
    }
}
