using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using Guide;


namespace Kompas
{
     //TODO: XML
     /// <summary>
     /// Класс, строящий деталь в компас-3D
     /// </summary>
    public class Builder
    {
        /// <summary>
        /// Экцемляр класса KompasConnector
        /// </summary>
        private KompasConnector _kompasConnector;
        /// <summary>
        /// Экцемляр класса GuideParameters
        /// </summary>
        private GuideParameters _guideParameters;
        /// <summary>
        /// Интерфейс документа-модели.
        /// </summary>
        private ksDocument3D _document3D;
        /// <summary>
        /// Интерфейс графического документа системы КОМПАС
        /// </summary>
        private ksDocument2D _document2D;
        /// <summary>
        /// Интерфейс детали или подсборки в составе сборки
        /// </summary>
        private ksPart _part;
        /// <summary>
        /// Интерфейс параметров эскиза.
        /// </summary>
        private ksSketchDefinition _sketchDefinition;
        /// <summary>
        /// Указатель на интерфейс плоскости
        /// </summary>
        private ksEntity _currentPlan;
        /// <summary>
        /// Интерфейс макроэлемента документа-модели
        /// </summary>
        private ksEntity _sketch;
        /// <summary>
        /// Номер структуры хранящий центр оружности и две точки касания с прямыми
        /// </summary>
        private const int CON_STRUCT_TYPE = 41;

        /// <summary>
        /// Конструктор для создания объекта Builder
        /// </summary>
        /// <param name="kompasConnector">Обект KompasConnector</param>
        /// <param name="guideParameters">Параметры детали</param>
        public Builder(KompasConnector kompasConnector, GuideParameters guideParameters)
        {
            _kompasConnector = kompasConnector;
            _guideParameters = guideParameters;
        }
        public void Build()
        {
            CreateDocument();
            CreateGuide();
            CutAttachmentStroke();
            CreateHole();
        }
        /// <summary>
        /// Создание документы, в котором будет построена деталь
        /// </summary>
        private void CreateDocument()
        {
            KompasObject Kompas = _kompasConnector.Kompas;
            _document3D = (ksDocument3D)Kompas.Document3D();
            _document3D.Create(false, true);
            _document2D = (ksDocument2D)Kompas.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
        }
        /// <summary>
        /// Создание направляюще без отверстия для крепления к поверхности
        /// </summary>
        //TODO: Вынести подсчет координат точек в отделюную функцию
        private void CreateGuide()
        {
            KompasObject kompas = _kompasConnector.Kompas;
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            double offset = _guideParameters.GuideWidth / 2;
            double[,] points = new double[4, 2] 
            { { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 } };
            //TODO: toconst
            ksCON[] con = new ksCON[5]
            {
                kompas.GetParamStruct(CON_STRUCT_TYPE),
                kompas.GetParamStruct(CON_STRUCT_TYPE),
                kompas.GetParamStruct(CON_STRUCT_TYPE),
                kompas.GetParamStruct(CON_STRUCT_TYPE),
                kompas.GetParamStruct(CON_STRUCT_TYPE)
            };
            double radius = 2;
            //находим крайние точки на эскизе
            /////////////////////////////
            for (int i = 0; i < 2; i++)
            {
                points[i, 0] -= _guideParameters.GuideLength;
            }
            points[0, 1] -= offset;
            points[1, 1] += offset;
            for (int i = 2; i < 4; i++)
            {
                _document2D.ksMovePoint(ref points[i, 0], ref points[i, 1],
                    180 - _guideParameters.GuideAngle,
                    _guideParameters.GuideWidth
                    + _guideParameters.AttachmentStrokeLength
                    + 0.5*_guideParameters.AttachmentStrokeWidth);
            }
            var line  = _document2D.ksLineSeg(0, 0, points[2,0],points[2,1], 6);
            ksMathematic2D ksmathematic=kompas.GetMathematic2D();

            double var = ksmathematic.ksGetCurvePerpendicular(line,
                points[2, 0], points[2, 1]);
            _document2D.ksMovePoint(ref points[2, 0], ref points[2, 1],
                var, +offset);
            _document2D.ksMovePoint(ref points[3, 0], ref points[3, 1],
                var, -offset);
            //////////////////////////////

            //высчитываем координаты сглаживания в точках сгиба для 1 и 5 con
            //////////////////////////////
                ksmathematic.ksCouplingLineLine(points[0,0], points[0,1],
                    180, points[3,0], points[3,1],
                    -_guideParameters.GuideAngle, radius, con[4]);
                ksmathematic.ksCouplingLineLine(points[1,0], points[1,1],
                    180, points[2,0], points[2,1],
                    -_guideParameters.GuideAngle, radius, con[1]);
            //////////////////////////////

            //высчитываем координаты сглаживания на углах для 0,2,3 con
            //////////////////////////////
            
            ksmathematic.ksCouplingLineLine(points[1, 0], points[1, 1], 90,
                points[1, 0], points[1, 1],
                180,radius, con[0]);
            ksmathematic.ksCouplingLineLine(points[2, 0], points[2, 1],
                180 - _guideParameters.GuideAngle , points[2, 0], points[2, 1],
                 90 -_guideParameters.GuideAngle + 180, radius, con[2]);
            ksmathematic.ksCouplingLineLine(points[3, 0], points[3, 1],
                180 - _guideParameters.GuideAngle, points[3, 0], points[3, 1],
                 90 - _guideParameters.GuideAngle + 180, radius, con[3]);
            //////////////////////////////

            int con14Index=0;
            short con14rotation = 0;
            if (_guideParameters.GuideAngle<180)
            {
                 con14Index = 3;
                con14rotation = 1;

            }
            else if (_guideParameters.GuideAngle > 180)
            {
                 con14Index = 2;
                con14rotation = -1;
            }
            if (_guideParameters.GuideAngle != 180)
            {
                _document2D.ksArcByPoint(con[1].GetXc(con14Index),
                    con[1].GetYc(con14Index)+ offset, radius,
                con[1].GetX1(con14Index), con[1].GetY1(con14Index)+ offset,
                 con[1].GetX2(con14Index), con[1].GetY2(con14Index)+ offset,
                 con14rotation, 1);
                
                _document2D.ksArcByPoint(con[4].GetXc(con14Index),
                    con[4].GetYc(con14Index)+ offset, radius,
                con[4].GetX1(con14Index), con[4].GetY1(con14Index)+ offset,
                 con[4].GetX2(con14Index), con[4].GetY2(con14Index)+ offset,
                 con14rotation, 1);
                _document2D.ksLineSeg(con[0].GetX2(1), con[0].GetY2(1)+ offset,
                    con[1].GetX1(con14Index), con[1].GetY1(con14Index)+ offset, 1);
                _document2D.ksLineSeg(con[1].GetX2(con14Index),
                    con[1].GetY2(con14Index)+ offset, con[2].GetX1(1),
                    con[2].GetY1(1)+ offset, 1);
                _document2D.ksLineSeg(con[4].GetX2(con14Index),
                    con[4].GetY2(con14Index)+ offset, con[3].GetX1(2),
                    con[3].GetY1(2)+ offset, 1);
                _document2D.ksLineSeg(con[4].GetX1(con14Index)
                    , con[4].GetY1(con14Index)+ offset, points[0,0],
                    points[0,1]+ offset, 1);
            }
            else{
                _document2D.ksLineSeg(con[0].GetX2(1),
                    con[0].GetY2(1)+ offset, con[2].GetX1(1),
                    con[2].GetY1(1) + offset, 1);
                _document2D.ksLineSeg(points[0, 0],
                    points[0, 1] + offset, con[3].GetX1(2),
                    con[3].GetY1(2) + offset, 1);
            }

            _document2D.ksLineSeg(points[0, 0],
                points[0, 1] + offset, con[0].GetX1(1),
                con[0].GetY1(1) + offset, 1);

            _document2D.ksArcByPoint(con[0].GetXc(1),
                con[0].GetYc(1) + offset, radius,
                con[0].GetX1(1), con[0].GetY1(1) + offset,
                 con[0].GetX2(1), con[0].GetY2(1) + offset, -1, 1);

            _document2D.ksArcByPoint(con[2].GetXc(1),
                con[2].GetYc(1) + offset, radius,
               con[2].GetX1(1), con[2].GetY1(1) + offset,
                con[2].GetX2(1), con[2].GetY2(1) + offset, -1, 1);

            _document2D.ksLineSeg(con[3].GetX2(2),
                con[3].GetY2(2) + offset, con[2].GetX2(1),
                con[2].GetY2(1) + offset, 1);

            _document2D.ksArcByPoint(con[3].GetXc(2),
                con[3].GetYc(2) + offset, radius,
               con[3].GetX1(2), con[3].GetY1(2) + offset,
                con[3].GetX2(2), con[3].GetY2(2) + offset, 1, 1);

            _sketchDefinition.EndEdit();

            //Выдавливание
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksBossExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            // тип выдавливания (строго на глубину)
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = _guideParameters.GuideDepth;
            entityExtrude.Create();
        }
        /// <summary>
        /// Выдавливание из модели отвестия для хода направляющей
        /// </summary>
        private void CutAttachmentStroke()
        {
            KompasObject kompas = _kompasConnector.Kompas;
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();
            double offset = _guideParameters.GuideWidth / 2;
            double[] point = new double[2] { 0, 0 };
            // сдвинуть точку но расстояние под углом к оси ох
            _document2D.ksMovePoint(ref point[ 0], ref point[ 1], 180 - _guideParameters.GuideAngle,
                    _guideParameters.GuideWidth
                    + _guideParameters.AttachmentStrokeLength
                    + 0.5 * _guideParameters.AttachmentStrokeWidth);
            var line = _document2D.ksLineSeg(0, 0, point[0], point[1], 6);
            ksMathematic2D ksmathematic = kompas.GetMathematic2D();
            double var = ksmathematic.ksGetCurvePerpendicular(line, point[0], point[1]);

            double[,] attachmentpoints = new double[6, 2]
            { { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 } };
            for (int i = 0; i < 6; i++)
            {
                if (i<3)
                {
                    _document2D.ksMovePoint(
                        ref attachmentpoints[i, 0], 
                        ref attachmentpoints[i, 1],
                        180 - _guideParameters.GuideAngle,
                        0.5 * (_guideParameters.GuideWidth + _guideParameters.AttachmentStrokeWidth));
                }
                else
                {
                    _document2D.ksMovePoint(
                        ref attachmentpoints[i, 0],
                        ref attachmentpoints[i, 1],
                        180 - _guideParameters.GuideAngle,
                        0.5 * (_guideParameters.GuideWidth + _guideParameters.AttachmentStrokeWidth)
                        + _guideParameters.AttachmentStrokeLength);
                }
            }
            _document2D.ksMovePoint(
                ref attachmentpoints[1, 0],
                ref attachmentpoints[1, 1],
                var, _guideParameters.AttachmentStrokeWidth / 2);

            _document2D.ksMovePoint(
                ref attachmentpoints[2, 0], 
                ref attachmentpoints[2, 1], var, 
                -_guideParameters.AttachmentStrokeWidth / 2);

            _document2D.ksMovePoint(
                ref attachmentpoints[4, 0], 
                ref attachmentpoints[4, 1], var, 
                _guideParameters.AttachmentStrokeWidth / 2);

            _document2D.ksMovePoint(
                ref attachmentpoints[5, 0], 
                ref attachmentpoints[5, 1], var, 
                -_guideParameters.AttachmentStrokeWidth / 2);

            _document2D.ksLineSeg(attachmentpoints[1, 0], 
                attachmentpoints[1, 1] + offset,
                attachmentpoints[4, 0],
                attachmentpoints[4, 1] + offset, 1);
            _document2D.ksLineSeg(attachmentpoints[2, 0],
                attachmentpoints[2, 1] + offset,
                attachmentpoints[5, 0],
                attachmentpoints[5, 1] + offset, 1);

            _document2D.ksArcByPoint(attachmentpoints[0, 0],
                attachmentpoints[0, 1] + offset,
                _guideParameters.AttachmentStrokeWidth / 2,
               attachmentpoints[1, 0], attachmentpoints[1, 1] + offset,
                attachmentpoints[2, 0], attachmentpoints[2, 1] + offset,
                1, 1);
            _document2D.ksArcByPoint(attachmentpoints[3, 0],
                attachmentpoints[3, 1] + offset,
                _guideParameters.AttachmentStrokeWidth / 2,
               attachmentpoints[4, 0], attachmentpoints[4, 1] + offset,
                attachmentpoints[5, 0], attachmentpoints[5, 1] + offset,
                -1, 1);

            _sketchDefinition.EndEdit();

            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksCutExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = -_guideParameters.GuideDepth;
            entityExtrude.Create();
        }

        /// <summary>
        /// Создание отверстия для крепления
        /// </summary>
        private void CreateHole()
        {
            KompasObject kompas = _kompasConnector.Kompas;
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();
            //TODO: toconst

            double wallReserve = 5;
            double headReserve = 1.5*_guideParameters.HoleDiameter;
            //Деления на 2 служит переводом диаметра в радиус
            double[,] points = new double[5, 2] {
                { -_guideParameters.GuideLength, 0 },
                { -_guideParameters.GuideLength, wallReserve+headReserve/2 },
                { -_guideParameters.GuideLength+2*wallReserve+headReserve, 0 },
                { -_guideParameters.GuideLength+2*wallReserve+headReserve,wallReserve+headReserve/2 },
                { -_guideParameters.GuideLength+wallReserve+headReserve/2,wallReserve+headReserve/2 } };

            _document2D.ksLineSeg(points[0, 0], points[0, 1], points[1, 0], points[1, 1], 1);
            _document2D.ksLineSeg(points[0, 0], points[0, 1], points[2, 0], points[2, 1], 1);
            _document2D.ksLineSeg(points[2, 0], points[2, 1], points[3, 0], points[3, 1], 1);
            _document2D.ksArcByPoint(points[4, 0], points[4, 1], _guideParameters.HoleDiameter*0.75 + 5,
                points[1, 0], points[1, 1], points[3, 0], points[3, 1], -1, 1);
            _document2D.ksCircle(points[4, 0], points[4, 1], _guideParameters.HoleDiameter / 2, 1);
            

            _sketchDefinition.EndEdit();

            //Выдавливание
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksBossExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            // тип выдавливания (строго на глубину)
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = _guideParameters.GuideWidth/2;
            entityExtrude.Create();
        }
    }
}
