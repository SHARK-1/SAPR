using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
        //TODO: RSDN
    public struct Range
    {
         //TODO: XML
         //TODO: на свойства
        public double Min;
        public double Max;
        /// <summary>
        /// Конструктор, задающий минимальное и максимальное значение
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public Range(double min, double max)
        {
            Min = min;
            Max = max;
        }

    }
}
