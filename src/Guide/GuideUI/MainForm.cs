using System;
using System.Drawing;
using System.Windows.Forms;
using Kompas;
using Guide;
using System.Collections.Generic;
using System.Linq;


namespace GuideUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект холнящий подключение к компасу
        /// </summary>
        KompasConnector _kompasConnector;
        /// <summary>
        /// Объект хранящий параметры направляющей
        /// </summary>
        GuideParameters _guideParameters;
        /// <summary>
        /// Словарь для хранения элеменов Label, 
        /// с записями максимальных и минимальных значений
        /// </summary>
        private readonly Dictionary<ParameterNames, Label>
            _labelDictionary;
        /// <summary>
        /// Словарь для хранения элеменов TextBox с парапетрами
        /// </summary>
        private readonly Dictionary<ParameterNames, TextBox>
            _textBoxDictionary;
        /// <summary>
        /// Словарь для хранения изображений параметров
        /// </summary>
        private readonly Dictionary<ParameterNames, Bitmap>
            _imageDictionary;
        /// <summary>
        /// Форма приложения
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _kompasConnector = new KompasConnector();
            string path = FileManager.DirectoryPath 
                + FileManager.FileName;
            _guideParameters = FileManager.LoadFile(path);
            ValidateAllValues();
            _labelDictionary = new Dictionary<ParameterNames, Label>
            {
                { ParameterNames.AttachmentStrokeLength,
                    AttachmentStrokeLengthLabel },
                { ParameterNames.AttachmentStrokeWidth,
                    AttachmentStrokeWidthLabel },
                { ParameterNames.GuideLength, GuideLengthLabel },
                { ParameterNames.GuideWidth, GuideWidthLabel },
                { ParameterNames.GuideDepth, GuideDepthLabel },
                { ParameterNames.GuideAngle,GuideAngleLabel },
                { ParameterNames.HoleDiameter, HoleDiameterLabel }
            };
            _textBoxDictionary = new Dictionary<ParameterNames, TextBox>
            {
                { ParameterNames.AttachmentStrokeLength,
                    AttachmentStrokeLengthTextBox },
                { ParameterNames.AttachmentStrokeWidth,
                    AttachmentStrokeWidthTextBox },
                { ParameterNames.GuideLength, GuideLengthTextBox },
                { ParameterNames.GuideWidth, GuideWidthTextBox },
                { ParameterNames.GuideDepth, GuideDepthTextBox },
                { ParameterNames.GuideAngle,GuideAngleTextBox },
                { ParameterNames.HoleDiameter, HoleDiameterTextBox }
            };
            _imageDictionary = new Dictionary<ParameterNames, Bitmap>
            {
                {ParameterNames.GuideLength,
                    global::GuideUI.Properties.Resources._1},
                {ParameterNames.GuideWidth,
                    global::GuideUI.Properties.Resources._2},
                {ParameterNames.GuideDepth,
                    global::GuideUI.Properties.Resources._3},
                {ParameterNames.GuideAngle,
                    global::GuideUI.Properties.Resources._7},
                {ParameterNames.AttachmentStrokeLength,
                    global::GuideUI.Properties.Resources._4},
                {ParameterNames.AttachmentStrokeWidth,
                    global::GuideUI.Properties.Resources._5},
                {ParameterNames.HoleDiameter,
                    global::GuideUI.Properties.Resources._6},
            };
            LoadParametersToForm();
        }
        /// <summary>
        /// Событие, для построения модели
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _kompasConnector.ConnectToKompas();
            Builder builder = new Builder(_kompasConnector, _guideParameters);
            builder.Build();
        }
        /// <summary>
        /// Заносится значение из TextBox в GuideParameters по имени
        /// </summary>
        /// <param name="textBox">
        /// TextBox из которого берется значение</param>
        /// <param name="basicParameter">
        /// Имя свойства из GuideParameters</param>
        /// <param name="dependedParameter">
        /// Имя зависимого свойства из GuideParameters</param>
        private void CheckValueInTextBox(
            TextBox textBox,
            ParameterNames basicParameter,
            ParameterNames dependedParameter=ParameterNames.None)
        {
            try
            {
                double value = double.Parse(textBox.Text);
                var propertyInfo = typeof(GuideParameters).
                    GetProperty(basicParameter.ToString());
                propertyInfo.SetValue(_guideParameters, value);
                textBox.BackColor = Color.White;
                if (dependedParameter!=ParameterNames.None)
                {
                    Range range =
                        _guideParameters.RangeDictionary[dependedParameter];
                    _labelDictionary[dependedParameter].Text=
                        $"({range.Min} - {range.Max} мм)";
                    CheckValueInTextBox(
                        _textBoxDictionary[dependedParameter],
                        dependedParameter);
                }
            }
            catch (FormatException e)
            {
                textBox.BackColor = Color.Pink;
                MessageBox.Show(e.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                textBox.BackColor = Color.Pink;
                MessageBox.Show(e.InnerException.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Проверка на корректность ввода во всех полях
        /// </summary>
        private void ValidateAllValues()
        {
            try
            {
                GuideParameters checkParameters = new GuideParameters();
                checkParameters.GuideLength =
                    double.Parse(GuideLengthTextBox.Text);
                checkParameters.GuideWidth =
                    double.Parse(GuideWidthTextBox.Text);
                checkParameters.GuideDepth =
                    double.Parse(GuideDepthTextBox.Text);
                checkParameters.AttachmentStrokeLength =
                    double.Parse(AttachmentStrokeLengthTextBox.Text);
                checkParameters.AttachmentStrokeWidth =
                    double.Parse(AttachmentStrokeWidthTextBox.Text);
                checkParameters.HoleDiameter =
                    double.Parse(HoleDiameterTextBox.Text);
                checkParameters.GuideAngle =
                    double.Parse(GuideAngleTextBox.Text);
                FileManager.SaveFile(
                    _guideParameters,
                    FileManager.DirectoryPath,
                    FileManager.FileName);
                BuildButton.Enabled = true;
            }
            catch
            {
                BuildButton.Enabled = false;
            }
        }
        /// <summary>
        /// Загрузка параметров модели на форму
        /// </summary>
        private void LoadParametersToForm()
        {
            var ranges = _guideParameters.RangeDictionary;
            foreach (ParameterNames parameterName 
                in _textBoxDictionary.Keys)
            {
                var propertyInfo = typeof(GuideParameters).
                    GetProperty(parameterName.ToString());
                _textBoxDictionary[parameterName].Text = 
                    propertyInfo.GetValue(_guideParameters).ToString();
                Range range = ranges[parameterName];
                
                var stringUnit = parameterName == ParameterNames.GuideAngle 
                        ? "°"
                        : "мм";
                _labelDictionary[parameterName].Text =
                    $"({range.Min} - {range.Max}{stringUnit})";
            }
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var key = _textBoxDictionary.
                FirstOrDefault(x => x.Value == (TextBox)sender).Key;
            CheckValueInTextBox((TextBox)sender, key);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            var key = _textBoxDictionary.
                FirstOrDefault(x => x.Value == (TextBox)sender).Key;
            pictureBox1.Image = _imageDictionary[key];
        }
    }
}