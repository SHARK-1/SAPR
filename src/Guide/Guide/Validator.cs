namespace Guide
{
    public static class Validator
    {
        /// <summary>
        /// Проверка, входит ли значение в диапозон
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>True если значение входит в диапозон,
        /// False если значение не входит в диапозон</returns>
        public static bool ValidateRange(double value, double min,double max)
        {
            return (value >= min && value <= max);
        }
    }
}
