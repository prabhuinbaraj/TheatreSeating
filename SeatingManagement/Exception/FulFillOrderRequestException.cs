namespace SeatingManagement.Exception
{
    public class FulFillOrderRequestException : System.Exception
    {
        public FulFillOrderRequestException(string fulfilOrderRequestFailure)
            : base (fulfilOrderRequestFailure)
        {
        }
    }
}
