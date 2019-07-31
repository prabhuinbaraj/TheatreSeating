using System;
using System.Collections.Generic;
using System.Text;

namespace SeatingManagement.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Theatre Seat Management");
            Console.WriteLine(GetUsage());

            try
            {
                var layoutInput = new List<string>();
                var input = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(input))
                {
                    layoutInput.Add(input);
                    input = Console.ReadLine();
                }
                if (layoutInput.Count.Equals(0))
                {
                    throw new ArgumentNullException("Invalid Layout");
                }

                var ticketRequests = new List<string>();
                input = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(input))
                {
                    ticketRequests.Add(input);
                    input = Console.ReadLine();
                }
                if (ticketRequests.Count.Equals(0))
                {
                    throw new ArgumentNullException("Invalid Ticket Request");
                }

                Theatre.Instance.ParseLayout(layoutInput);
                Theatre.Instance.ProcessTicketRequests(new PatronMail(ticketRequests));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Exception - {ex.Message}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public static string GetUsage()
        {
            var usage = new StringBuilder();
            usage.AppendLine("Please provide the theatre layout information (Row Sections separated by space)");
            usage.AppendLine("-----------------------------------Example-------------------------------------");
            usage.AppendLine("6 6");
            usage.AppendLine("3 5 5 3");
            usage.AppendLine("4 6 6 4");
            usage.AppendLine("2 8 8 2");
            usage.AppendLine("6 6");
            usage.AppendLine("Provide the empty line before entering the ticket requests");
            usage.AppendLine("Smith 2");
            usage.AppendLine("Jones 5");
            usage.AppendLine("Davis 6");
            usage.AppendLine("Wilson 100");
            usage.AppendLine("Johnson 3");
            usage.AppendLine("Williams 4");
            usage.AppendLine("Brown 8");
            usage.AppendLine("Miller 12");
            usage.AppendLine("------------------------------------End-----------------------------------------");
            return usage.ToString();
        }
    }
}
