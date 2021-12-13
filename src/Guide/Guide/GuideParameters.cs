using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
     //TODO: XML
    public class GuideParameters
    {
        private double _guideLength;
        private double _guideWidth;
        private double _guideDepth;
        private double _guideAngle;
        private double _holeDiameter;
        private double _attachmentStrokeLength;
        private double _attachmentStrokeWidth;

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
                    throw new Exception("Значение выходит за пределы допустимых значений");
                }
            }
        }
        /// <summary>
        /// Свойство параметра ширины направляющей
        /// </summary>
        public double GuideWidth
        {
            get { return _guideWidth; }
            set {
                Range range = _rangeDictionary[ParametersEnum.GuideWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                        //TODO: RSDN
                    _guideWidth = value;
                    _rangeDictionary[ParametersEnum.AttachmentStrokeWidth] = new Range(0.3 * _guideWidth, 0.5 * _guideWidth);
                }
                else
                {
                    throw new Exception("Значение выходит за пределы допустимых значений");
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
                    throw new Exception("Значение выходит за пределы допустимых значений");
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
                    throw new Exception("Значение выходит за пределы допустимых значений");
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
                    throw new Exception("Значение выходит за пределы допустимых значений");
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
                    throw new Exception("Значение выходит за пределы допустимых значений");
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
                    throw new Exception("Значение выходит за пределы допустимых значений");
                }
            }
        }

        /// <summary>
        /// Свойство для максимальных и минимальных значения параметров
        /// </summary>
        public Dictionary<ParametersEnum, Range> RangeDictionary => _rangeDictionary;
    }
}
