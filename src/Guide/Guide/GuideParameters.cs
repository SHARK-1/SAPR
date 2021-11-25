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
        private double _holeRadius;
        private double _attachmentStrokeLength;
        private double _attachmentStrokeWidth;
        private Dictionary<ParametersEnum, Range> _rangeDictionary;
        
        /// <summary>
        /// Создание экземпляра GuideParameters c значениями по умолчанию.
        /// </summary>
        public GuideParameters()
        {
            _guideLength = 1;
            _guideWidth = 1;
            _guideDepth = 1;
            _guideAngle = 1;
            _holeRadius = 1;
            _attachmentStrokeLength = 1;
            _attachmentStrokeWidth = 1;
            _rangeDictionary = new Dictionary<ParametersEnum, Range>();
            _rangeDictionary.Add(ParametersEnum.GuideLength, new Range(1, 1));
            _rangeDictionary.Add(ParametersEnum.GuideWidth, new Range(1, 1));
            _rangeDictionary.Add(ParametersEnum.GuideDepth, new Range(1, 1));
            _rangeDictionary.Add(ParametersEnum.GuideAngle, new Range(1, 1));
            _rangeDictionary.Add(ParametersEnum.HoleRadius, new Range(1, 1));
            _rangeDictionary.Add(ParametersEnum.AttachmentStrokeLength, new Range(1, 1));
            _rangeDictionary.Add(ParametersEnum.AttachmentStrokeWidth, new Range(1, 1));
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
            set { }
        }
        public double GuideDepth
        {
            get { return _guideDepth; }
            set { }
        }
        public double GuideAngle
        {
            get { return _guideAngle; }
            set { }
        }
        public double HoleRadius
        {
            get { return _holeRadius; }
            set { }
        }
        public double AttachmentStrokeLength
        {
            get { return _attachmentStrokeLength; }
            set { }
        }
        public double AttachmentStrokeWidth
        {
            get { return _attachmentStrokeWidth; }
            set { }
        }

        public Dictionary<ParametersEnum, Range> RangeDictionary
        {
            get { return _rangeDictionary; }
            set { }
        }
    }
}
