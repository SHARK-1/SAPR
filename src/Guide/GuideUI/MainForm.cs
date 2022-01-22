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
        private readonly Dictionary<ParametersEnum, Label> _labelDictionary;
        /// <summary>
        /// Словарь для хранения элеменов TextBox с парапетрами
        /// </summary>
        private readonly Dictionary<ParametersEnum, TextBox> _textBoxDictionary;
        /// <summary>
        /// Форма приложения
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _kompasConnector = new KompasConnector();
            string path = FileManager._directoryPath + FileManager._fileName;
            _guideParameters = FileManager.LoadFile(path);
            ValidateAllValues();
            _labelDictionary = new Dictionary<ParametersEnum, Label>
            {
                { ParametersEnum.AttachmentStrokeLength, AttachmentStrokeLengthLabel },
                { ParametersEnum.AttachmentStrokeWidth, AttachmentStrokeWidthLabel },
                { ParametersEnum.GuideLength, GuideLengthLabel },
                { ParametersEnum.GuideWidth, GuideWidthLabel },
                { ParametersEnum.GuideDepth, GuideDepthLabel },
                { ParametersEnum.GuideAngle,GuideAngleLabel },
                { ParametersEnum.HoleDiameter, HoleDiameterLabel }
            };
            _textBoxDictionary = new Dictionary<ParametersEnum, TextBox>
            {
                { ParametersEnum.AttachmentStrokeLength, AttachmentStrokeLengthTextBox },
                { ParametersEnum.AttachmentStrokeWidth, AttachmentStrokeWidthTextBox },
                { ParametersEnum.GuideLength, GuideLengthTextBox },
                { ParametersEnum.GuideWidth, GuideWidthTextBox },
                { ParametersEnum.GuideDepth, GuideDepthTextBox },
                { ParametersEnum.GuideAngle,GuideAngleTextBox },
                { ParametersEnum.HoleDiameter, HoleDiameterTextBox }
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
        /// <param name="textBox">TextBox из которого берется значение</param>
        /// <param name="basicParameter">Имя свойства из GuideParameters</param>
        /// <param name="dependedParameter">Имя зависимого свойства из GuideParameters</param>
        private void CheckValueInTextBox(
            TextBox textBox,
            ParametersEnum basicParameter,
            ParametersEnum dependedParameter=ParametersEnum.None)
        {
            try
            {
                double value = double.Parse(textBox.Text);
                var propertyInfo = typeof(GuideParameters).
                    GetProperty(basicParameter.ToString());
                propertyInfo.SetValue(_guideParameters, value);
                textBox.BackColor = Color.White;
                if (dependedParameter!=ParametersEnum.None)
                {
                    Range range = _guideParameters.RangeDictionary[dependedParameter];
                    _labelDictionary[dependedParameter].Text= $"({range.Min} - {range.Max} мм)";
                    CheckValueInTextBox(_textBoxDictionary[dependedParameter], dependedParameter);
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

        //TODO: дубль
        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideLengthTextBox_Leave(object sender, EventArgs e)
        {
            //TODO:
            var enum1 = _textBoxDictionary.
                FirstOrDefault(x => x.Value == (TextBox)sender).Key;
            CheckValueInTextBox((TextBox)sender, enum1);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideWidthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.GuideWidth, ParametersEnum.AttachmentStrokeWidth);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void AttachmentStrokeWidthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.AttachmentStrokeWidth, ParametersEnum.AttachmentStrokeLength);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void AttachmentStrokeLengthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.AttachmentStrokeLength);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideDepthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.GuideDepth);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void HoleDiameterTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.HoleDiameter);
            ValidateAllValues();
        }

        /// <summary>
        /// Событие, при фотрере фокуса с элемента TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideAngleTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.GuideAngle);
            ValidateAllValues();
        }

        /// <summary>
        /// Проверка на корректность ввода во всех полях
        /// </summary>
        private void ValidateAllValues()
        {
            try
            {
                GuideParameters checkParameters=new GuideParameters();
                checkParameters.GuideLength = double.Parse(GuideLengthTextBox.Text);
                checkParameters.GuideWidth = double.Parse(GuideWidthTextBox.Text);
                checkParameters.GuideDepth = double.Parse(GuideDepthTextBox.Text);
                checkParameters.AttachmentStrokeLength = double.Parse(AttachmentStrokeLengthTextBox.Text);
                checkParameters.AttachmentStrokeWidth = double.Parse(AttachmentStrokeWidthTextBox.Text);
                checkParameters.HoleDiameter = double.Parse(HoleDiameterTextBox.Text);
                checkParameters.GuideAngle = double.Parse(GuideAngleTextBox.Text);
                FileManager.SaveFile(_guideParameters,FileManager._directoryPath);
                BuildButton.Enabled = true;
            }
            catch
            {
                BuildButton.Enabled = false;
            }
        }

        //TODO: дубль
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideLengthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._1;
        }
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideWidthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._2;
        }
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideDepthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._3;
        }
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void AttachmentStrokeLengthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._4;
        }
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void AttachmentStrokeWidthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._5;
        }
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void HoleDiameterTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._6;
        }
        /// <summary>
        /// Событие, при наведении фокуса на элемент TextBox
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Передынные аргументы</param>
        private void GuideAngleTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._7;
        }

        /// <summary>
        /// Загрузка параметров модели на форму
        /// </summary>
        private void LoadParametersToForm()
        {
            var ranges = _guideParameters.RangeDictionary;
            foreach (ParametersEnum parameterName in _textBoxDictionary.Keys)
            {
                var propertyInfo = typeof(GuideParameters).
                    GetProperty(parameterName.ToString());
                _textBoxDictionary[parameterName].Text = 
                    propertyInfo.GetValue(_guideParameters).ToString();
                Range range = ranges[parameterName];
                
                var stringUnit = parameterName == ParametersEnum.GuideAngle 
                        ? "°"
                        : "мм";
                _labelDictionary[parameterName].Text =
                    $"({range.Min} - {range.Max}{stringUnit})";
            }
        }
    }
}