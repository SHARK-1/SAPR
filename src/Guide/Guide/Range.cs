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
        private double _min;
        private double _max;
        /// <summary>
        /// Конструктор, задающий минимальное и максимальное значение
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public Range(double min, double max)
        {
            _min = min;
            _max = max;
        }
        public double Min{
            get { return _min; }
            set { _min = value; } 
        }
        public double Max
        {
            get { return _max; }
            set { _max = value; }
        }

    }
}
