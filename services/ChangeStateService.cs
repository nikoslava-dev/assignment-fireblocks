using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using assignment.models;

namespace assignment.services
{
    public class ChangeStateService : BaseActionService
    {
        public override void Preform(string value)
        {
            StateService stateService = StateService.GetInstance;
            Dictionary<int, StateEntity> state = stateService.State;
            string[] values = value.Split(" ");
            if(!ValidationService.IsValid(values))
            {
                Console.WriteLine("Input not valid");
                return;
            }
            

            StateEntity entity = stateService.ParseValue(values[2]);
            if(entity == null)
            {
                Console.WriteLine("Can not parse value");
                
                return;
            }
            
            state[int.Parse(values[1])] = entity;
            Console.WriteLine("Cell #{0} changed to {1}", values[1], values[2]);
        }
    }
}