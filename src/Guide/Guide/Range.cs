namespace Guide
{
    /// <summary>
    /// Структура с максимальным и минимальным значение параметра
    /// </summary>
    public struct Range
    {
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
        /// <summary>
        /// Свройство для минимального значения
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Свройство для минимального значения
        /// </summary>
        public double Max { get; set; }
    }
}
