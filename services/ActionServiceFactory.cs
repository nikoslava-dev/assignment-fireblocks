using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.services
{
    public static class ActionServiceFactory
    {
        public static BaseActionService Create(string value)
        {
            if(value.StartsWith("b"))
            {
                return new ChangeStateService();
            }
            else if(value == "a")
            {
                return new PrintStateService();
            }
            else
            {
                return null;
            }
        }
    }
}