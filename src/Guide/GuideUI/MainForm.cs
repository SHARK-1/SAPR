using System;
using System.Drawing;
using System.Windows.Forms;
using Kompas;
using Guide;
using System.Collections.Generic;


namespace GuideUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект холнящий подключение к компасу
        /// </summary>
        KompasConnector _kompasConnector;
        GuideParameters _guideParameters;
        /// <summary>
        /// Словарь для хранения элеменов Label, 
        /// с записями максимальных и минимальных значений
        /// </summary>
        private readonly Dictionary<ParametersEnum, Label> _labelDictionary;
        /// <summary>
        /// Словарь для хранения элеменов TextBox, с зависимыми парапетрами
        /// </summary>
        private readonly Dictionary<ParametersEnum, TextBox> _textBoxDictionary;
        public MainForm()
        {
            InitializeComponent();
            _guideParameters = new GuideParameters();
            ValidateAllValues();
            _labelDictionary = new Dictionary<ParametersEnum, Label>
            {
                { ParametersEnum.AttachmentStrokeLength, AttachmentStrokeLengthLabel },
                { ParametersEnum.AttachmentStrokeWidth, AttachmentStrokeWidthLabel }
            };
            _textBoxDictionary= new Dictionary<ParametersEnum, TextBox>
                            {
                { ParametersEnum.AttachmentStrokeLength, AttachmentStrokeLengthTextBox },
                { ParametersEnum.AttachmentStrokeWidth, AttachmentStrokeWidthTextBox }
            };
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _kompasConnector = new KompasConnector();
            _kompasConnector.ConnectToKompas();
            Builder builder = new Builder(_kompasConnector,_guideParameters);
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
                MessageBox.Show(e.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.BackColor = Color.Pink;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        //TODO: Дубли
        private void GuideLengthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender,ParametersEnum.GuideLength);
            ValidateAllValues();
        }

        //TODO: Дубли
        private void GuideWidthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.GuideWidth, ParametersEnum.AttachmentStrokeWidth);
            ValidateAllValues();
        }

        private void AttachmentStrokeWidthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.AttachmentStrokeWidth, ParametersEnum.AttachmentStrokeLength);
            ValidateAllValues();
        }

        private void AttachmentStrokeLengthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.AttachmentStrokeLength);
            ValidateAllValues();
        }

        //TODO: Дубли
        private void GuideDepthTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.GuideDepth);
            ValidateAllValues();
        }

        //TODO: Дубли
        private void HoleDiameterTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.HoleDiameter);
            ValidateAllValues();
        }

        //TODO: Дубли
        private void GuideAngleTextBox_Leave(object sender, EventArgs e)
        {
            CheckValueInTextBox((TextBox)sender, ParametersEnum.GuideAngle);
            ValidateAllValues();
        }

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
                BuildButton.Enabled = true;
            }
            catch
            {
                BuildButton.Enabled = false;
            }
        }

        private void GuideLengthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._1;
        }

        private void GuideWidthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._2;
        }

        private void GuideDepthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._3;
        }

        private void AttachmentStrokeLengthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._4;
        }

        private void AttachmentStrokeWidthTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._5;
        }

        private void HoleDiameterTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._6;
        }

        private void GuideAngleTextBox_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::GuideUI.Properties.Resources._7;
        }
    }
}