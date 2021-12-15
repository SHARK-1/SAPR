using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
        //TODO: RSDN
        /// <summary>
        /// Структура с максимальным и минимальным значение параметра направляющей
        /// </summary>
    public struct Range
    {
         //TODO: XML
         //TODO: на свойства
         /// <summary>
         /// Минимальное значение
         /// </summary>
        private double _min;
        /// <summary>
        /// Максимальное значение значение
        /// </summary>
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
        /// <summary>
        /// Свройство для минимального значения
        /// </summary>
        public double Min{
            get { return _min; }
            set { _min = value; } 
        }
        /// <summary>
        /// Свройство для минимального значения
        /// </summary>
        public double Max
        {
            get { return _max; }
            set { _max = value; }
        }

    }
}
