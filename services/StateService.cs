using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.models;

namespace assignment.services
{
    public class StateService
    {
        public Dictionary<int, StateEntity> State{ get; set; }
        private StateService() 
        {
            State = new Dictionary<int, StateEntity>();
        }

        private static StateService instance = null;
        public static StateService GetInstance {
            get {
                if (instance == null) {
                    instance = new StateService();
                }
                return instance;
            }
        }

        public StateEntity? ParseValue(string value)
        {
            if (value == null || value == string.Empty)
            {
                return null;
            }

            if(value.Contains("="))
            {
                return new StateEntity(){ CellType = CellTypes.Expression, CellValue = value.Remove(0, 1) };
            }
            else 
            {
                return new StateEntity(){ CellType = CellTypes.Number, CellValue = value };
            }
        }
    }
}
