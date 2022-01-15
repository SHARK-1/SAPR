﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
     //TODO: XML
     /// <summary>
     /// Класс хранящий параметры направляющей
     /// </summary>
    public class GuideParameters
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
                    CallException(value, range.Min, range.Max);
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
                    CallException(value, range.Min, range.Max);
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
                    CallException(value, range.Min, range.Max);
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
                    CallException(value, range.Min, range.Max);
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
                    CallException(value, range.Min, range.Max);
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
                Range range = _rangeDictionary[ParametersEnum.AttachmentStrokeLength];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _attachmentStrokeLength = value;
                }
                else
                {
                    CallException(value, range.Min, range.Max);
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
                Range range = _rangeDictionary[ParametersEnum.AttachmentStrokeWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _attachmentStrokeWidth = value;
                    _rangeDictionary[ParametersEnum.AttachmentStrokeLength] = new Range(5 * _attachmentStrokeWidth, 90);
                }
                else
                {
                    CallException(value, range.Min, range.Max);
                }
            }
        }

        /// <summary>
        /// Свойство для максимальных и минимальных значения параметров
        /// </summary>
        public Dictionary<ParametersEnum, Range> RangeDictionary => _rangeDictionary;
        //TODO: В поле таком то введено тото
        private void CallException(double value,double min,double max)
        {
            throw new ArgumentException($"Введено {value}\n" +
                        $"Должно быть от {min} до {max}.");
        }
    }
}
