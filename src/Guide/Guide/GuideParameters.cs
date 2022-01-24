using System;
using System.Collections.Generic;

namespace Guide
{
    /// <summary>
    /// Класс хранящий параметры направляющей
    /// </summary>
    public class GuideParameters : IEquatable<GuideParameters>
    {
        /// <summary>
        /// Длинна направляющей
        /// </summary>
        private double _guideLength;
        /// <summary>
        /// Ширина направляющей
        /// </summary>
        private double _guideWidth;
        /// <summary>
        /// Толщина направляющей
        /// </summary>
        private double _guideDepth;
        /// <summary>
        /// Угол наклона направляющей
        /// </summary>
        private double _guideAngle;
        /// <summary>
        /// Диаметр отверстия
        /// </summary>
        private double _holeDiameter;
        /// <summary>
        /// Длина ходя крепления
        /// </summary>
        private double _attachmentStrokeLength;
        /// <summary>
        /// Ширина ходя крепления
        /// </summary>
        private double _attachmentStrokeWidth;
        /// <summary>
        /// Словарь хранящий минимальные и максимальные значения параметров
        /// </summary>
        private readonly Dictionary<ParameterNames, Range> _rangeDictionary;

        /// <summary>
        /// Создание экземпляра GuideParameters c значениями по умолчанию.
        /// </summary>
        public GuideParameters()
        {
            _guideLength = 50;
            _guideWidth = 10;
            _guideDepth = 5;
            _guideAngle = 65;
            _holeDiameter = 2;
            _attachmentStrokeLength = 15;
            _attachmentStrokeWidth = 3;
            _rangeDictionary = new Dictionary<ParameterNames, Range>
            {
                { ParameterNames.GuideLength, new Range(50, 150) },
                { ParameterNames.GuideWidth, new Range(10, 30) },
                { ParameterNames.GuideDepth, new Range(5, 20) },
                { ParameterNames.GuideAngle, new Range(65, 270) },
                { ParameterNames.HoleDiameter, new Range(2, 20) },
                { ParameterNames.AttachmentStrokeLength, new Range(15, 90) },
                { ParameterNames.AttachmentStrokeWidth, new Range(3, 5) }
            };
        }

        /// <summary>
        /// Свойство параметра длинны направляющей
        /// </summary>
        public double GuideLength
        {
            get { return _guideLength; }
            set
            {
                Range range = _rangeDictionary[ParameterNames.GuideLength];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideLength = value;
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "длина направляющей");
            }
        }
        /// <summary>
        /// Свойство параметра ширины направляющей
        /// </summary>
        public double GuideWidth
        {
            get { return _guideWidth; }
            set
            {
                Range range = _rangeDictionary[ParameterNames.GuideWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideWidth = value;
                    _rangeDictionary[ParameterNames.AttachmentStrokeWidth] =
                        new Range(0.3 * _guideWidth, 0.5 * _guideWidth);
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "ширина направляющеей");
            }
        }
        /// <summary>
        /// Свойство параметра толщины направляющей
        /// </summary>
        public double GuideDepth
        {
            get { return _guideDepth; }
            set
            {
                Range range = _rangeDictionary[ParameterNames.GuideDepth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideDepth = value;
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "толщина направляющей");
            }
        }
        /// <summary>
        /// Свойство параметра угла наклона направляющей
        /// </summary>
        public double GuideAngle
        {
            get { return _guideAngle; }
            set
            {
                Range range = _rangeDictionary[ParameterNames.GuideAngle];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideAngle = value;
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "Угол наклона направляющей");
            }
        }
        /// <summary>
        /// Свойство параметра диаметра отверстия для крепления к поверхности
        /// </summary>
        public double HoleDiameter
        {
            get { return _holeDiameter; }
            set
            {
                Range range = _rangeDictionary[ParameterNames.HoleDiameter];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _holeDiameter = value;
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "диаметр отверстия");
            }
        }
        /// <summary>
        /// Свойство параметра длины хода направляещей
        /// </summary>
        public double AttachmentStrokeLength
        {
            get { return _attachmentStrokeLength; }
            set
            {
                Range range =
                    _rangeDictionary[ParameterNames.AttachmentStrokeLength];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _attachmentStrokeLength = value;
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "длина хода крепления");
            }
        }
        /// <summary>
        /// Свойство параметра ширины хода направляещей
        /// </summary>
        public double AttachmentStrokeWidth
        {
            get { return _attachmentStrokeWidth; }
            set
            {
                Range range =
                    _rangeDictionary[ParameterNames.AttachmentStrokeWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _attachmentStrokeWidth = value;
                    //TODO: RSDN
                    _rangeDictionary[ParameterNames.AttachmentStrokeLength] =
                        new Range(5 * _attachmentStrokeWidth, 90);
                    return;
                }
                CallException(value, range.Min, range.Max,
                    "ширина хода крепления");
            }
        }

        /// <summary>
        /// Свойство для максимальных и минимальных значения параметров
        /// </summary>
        public Dictionary<ParameterNames, Range> RangeDictionary =>
            _rangeDictionary;

        //TODO: XML+
        /// <summary>
        /// Вызов исключения с сообщением об ошибке
        /// </summary>
        /// <param name="value">значение параметра</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="parameterName">Имя параметра</param>
        private void CallException(
            double value, double min, double max, string parameterName)
        {
            throw new ArgumentException(
                $"В поле \"{parameterName}\" введено {value}.\n" +
                $"Должно быть от {min} до {max}.");
        }
        /// <summary>
        /// Сравнение с другим объектом параметров
        /// </summary>
        /// <param name="other">Объект, с которым сравнивают</param>
        /// <returns></returns>
        public bool Equals(GuideParameters other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return _guideLength == other._guideLength &&
                   _guideWidth == other._guideWidth &&
                   _guideDepth == other._guideDepth &&
                   _guideAngle == other._guideAngle &&
                   _attachmentStrokeLength == other._attachmentStrokeLength &&
                   _attachmentStrokeWidth == other._attachmentStrokeWidth &&
                   _holeDiameter == other._holeDiameter;
        }
    }
}
