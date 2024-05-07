using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using assignment.models;

namespace assignment.services
{
    public class PrintStateService : BaseActionService
    {
        public override void Preform(string input = null)
        {
            Dictionary<int, StateEntity> state = StateService.GetInstance.State;
            StringBuilder sb = new StringBuilder();
            CalculateService calcService = new CalculateService();

            foreach(var item in state)
            {
                sb.AppendFormat("[{0}: {1}], ", item.Key, item.Value.CellType == CellTypes.Number ? item.Value.CellValue : calcService.Calculate(item.Value.CellValue));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}