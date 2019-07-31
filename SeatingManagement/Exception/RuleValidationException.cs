
namespace SeatingManagement
{
    /// <summary>
    /// Rule Validation exception
    /// </summary>
    public class RuleValidationException : System.Exception
    {
        public RuleValidationException(string validationFailure)
            : base (validationFailure)
        {
        }
    }
}
