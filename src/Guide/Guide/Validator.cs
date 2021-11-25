using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
    public static class Validator
    {
        public static bool ValidateRange(double value, double min,double max)
        {
            if (value >= min && value <= max) return true;
            else return false;
        }
    }
}
