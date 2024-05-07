using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace assignment.services
{
    public class ValidationService
    {
        public static bool IsValid(string[] input)
        {
            return input != null && input.Length == 3;
        }
    }
}