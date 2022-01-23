using System;
using System.Collections.Generic;

namespace Guide
{
     /// <summary>
     /// Класс хранящий параметры направляющей
     /// </summary>
    public class GuideParameters:IEquatable<GuideParameters>
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
        private readonly Dictionary<ParametersEnum, Range> _rangeDictionary;
        
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
            _rangeDictionary = new Dictionary<ParametersEnum, Range>
            {
                { ParametersEnum.GuideLength, new Range(50, 150) },
                { ParametersEnum.GuideWidth, new Range(10, 30) },
                { ParametersEnum.GuideDepth, new Range(5, 20) },
                { ParametersEnum.GuideAngle, new Range(65, 270) },
                { ParametersEnum.HoleDiameter, new Range(2, 20) },
                { ParametersEnum.AttachmentStrokeLength, new Range(15, 90) },
                { ParametersEnum.AttachmentStrokeWidth, new Range(3, 5) }
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
                Range range = _rangeDictionary[ParametersEnum.GuideLength];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideLength = value;
                }
                else
                {
                    CallException(value, range.Min, range.Max,
                        "длина направляющей");
                }
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
                Range range = _rangeDictionary[ParametersEnum.GuideWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideWidth = value;
                    _rangeDictionary[ParametersEnum.AttachmentStrokeWidth] =
                        new Range(0.3 * _guideWidth, 0.5 * _guideWidth);
                }
                else
                {
                    CallException(value, range.Min, range.Max, 
                        "ширина направляющеей");
                }
            }
        }
        /// <summary>
        /// Свойство параметра толщины направляющей
        /// </summary>
        public double GuideDepth
        {
            get { return _guideDepth; }
            set {
                Range range = _rangeDictionary[ParametersEnum.GuideDepth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideDepth = value;
                }
                else
                {
                    CallException(value, range.Min, range.Max,
                        "толщина направляющей");
                }
            }
        }
        /// <summary>
        /// Свойство параметра угла наклона направляющей
        /// </summary>
        public double GuideAngle
        {
            get { return _guideAngle; }
            set {
                Range range = _rangeDictionary[ParametersEnum.GuideAngle];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideAngle = value;
                }
                else
                {
                    CallException(value, range.Min, range.Max,
                        "Угол наклона направляющей");
                }
            }
        }
        /// <summary>
        /// Свойство параметра диаметра отверстия для крепления к поверхности
        /// </summary>
        public double HoleDiameter
        {
            get { return _holeDiameter; }
            set {
                Range range = _rangeDictionary[ParametersEnum.HoleDiameter];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _holeDiameter = value;
                }
                else
                {
                    CallException(value, range.Min, range.Max,
                        "диаметр отверстия");
                }
            }
        }
        /// <summary>
        /// Свойство параметра длины хода направляещей
        /// </summary>
        public double AttachmentStrokeLength
        {
            get { return _attachmentStrokeLength; }
            set {
                Range range = 
                    _rangeDictionary[ParametersEnum.AttachmentStrokeLength];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _attachmentStrokeLength = value;
                }
                else
                {
                    CallException(value, range.Min, range.Max, 
                        "длина хода крепления");
                }
            }
        }
        /// <summary>
        /// Свойство параметра ширины хода направляещей
        /// </summary>
        public double AttachmentStrokeWidth
        {
            get { return _attachmentStrokeWidth; }
            set {
                Range range = 
                    _rangeDictionary[ParametersEnum.AttachmentStrokeWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _attachmentStrokeWidth = value;
                    //TODO: RSDN
                    _rangeDictionary[ParametersEnum.AttachmentStrokeLength] =
                        new Range(5 * _attachmentStrokeWidth, 90);
                }
                else
                {
                    CallException(value, range.Min, range.Max,
                        "ширина хода крепления");
                }
            }
        }

        /// <summary>
        /// Свойство для максимальных и минимальных значения параметров
        /// </summary>
        public Dictionary<ParametersEnum, Range> RangeDictionary =>
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
            double value,double min,double max,string parameterName)
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
        /// <summary>
        /// Сравнение с другим объектом
        /// </summary>
        /// <param name="obj">Объект, с которым сравнивают</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((GuideParameters)obj);
        }
    }
}
