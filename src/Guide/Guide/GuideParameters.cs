using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{

    public class GuideParameters
    {
        private double _guideLength;
        private double _guideWidth;
        private double _guideDepth;
        private double _guideAngle;
        private double _holeDiameter;
        private double _attachmentStrokeLength;
        private double _attachmentStrokeWidth;
        private Dictionary<ParametersEnum, Range> _rangeDictionary;
        
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
            _rangeDictionary = new Dictionary<ParametersEnum, Range>();
            _rangeDictionary.Add(ParametersEnum.GuideLength, new Range(50, 150));
            _rangeDictionary.Add(ParametersEnum.GuideWidth, new Range(10, 30));
            _rangeDictionary.Add(ParametersEnum.GuideDepth, new Range(5, 20));
            _rangeDictionary.Add(ParametersEnum.GuideAngle, new Range(65, 270));
            _rangeDictionary.Add(ParametersEnum.HoleDiameter, new Range(2, 20));
            _rangeDictionary.Add(ParametersEnum.AttachmentStrokeLength, new Range(15, 90));
            _rangeDictionary.Add(ParametersEnum.AttachmentStrokeWidth, new Range(3, 5));
        }
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
        public double GuideWidth
        {
            get { return _guideWidth; }
            set {
                Range range = _rangeDictionary[ParametersEnum.GuideWidth];
                if (Validator.ValidateRange(value, range.Min, range.Max))
                {
                    _guideWidth = value;
                    _rangeDictionary[ParametersEnum.AttachmentStrokeWidth] = new Range(0.3 * _guideWidth, 0.5 * _guideWidth);
                }
                else
                {
                    throw new Exception("Значение выходит за пределы допустимых значений");
                }
            }
        }
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

        public Dictionary<ParametersEnum, Range> RangeDictionary
        {
            get { return _rangeDictionary; }
            set { }
        }
    }
}
