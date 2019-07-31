using System;

namespace SeatingManagement.OrderRule
{
    public class OrderRuleFactory
    {
        public static T Create<T>() where T : IOrderRule
        {
            return Activator.CreateInstance<T>();
        }
    }
}
