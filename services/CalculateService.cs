using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using assignment.models;

namespace assignment.services
{
    public class CalculateService
    {
        public double Calculate(string value)
        {
            value = FindReplaceIndexReference(value);
            double result = Convert.ToDouble(new DataTable().Compute(value, null));
            return result;
        }

        private string FindReplaceIndexReference(string value)
        {
            Dictionary<int, StateEntity> state = StateService.GetInstance.State;
            int index = value.IndexOf("{");
            while(index != -1)
            {
                string inx = value.Substring(index, 3);
                value = value.Replace(inx, state[int.Parse(inx.Replace("{", "").Replace("}", ""))].CellValue);
                index = value.IndexOf("{");
            }

            return value;
        }
    }
}