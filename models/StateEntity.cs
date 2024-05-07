using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.models
{
    public class StateEntity
    {
        public required CellTypes CellType { get; set; }
        public required string CellValue { get; set; }

    }
}