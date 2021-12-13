using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kompas6API5;
using KompasAPI7;
using Kompas6Constants3D;
using System.Runtime.InteropServices;
using Kompas;
using Guide;

//TODO: Заменить валидацию на запись в параметры. уточнить
//Проверка всех значений после каждого ввода, может сделать буллевый массив(или инной метод)?
namespace GuideUI
{
    public partial class MainForm : Form
    {
        KompasConnector _kompasConnector;
        GuideParameters _guideParameters;
        public MainForm()
        {
            InitializeComponent();
            _guideParameters = new GuideParameters();
            ValidateAllValues();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _kompasConnector = new KompasConnector();
            _kompasConnector.ConnectToKompas();
            Builder builder = new Builder(_kompasConnector,_guideParameters);
        }

        //TODO: Дубли
        private void CheckAttachmentStrokeWidth()
        {
            try
            {
                double attachmentStrokeWidth = double.Parse(AttachmentStrokeWidthTextBox.Text);
                _guideParameters.AttachmentStrokeWidth = attachmentStrokeWidth;
                AttachmentStrokeWidthTextBox.BackColor = Color.White;
                Range range = _guideParameters.RangeDictionary[ParametersEnum.AttachmentStrokeLength];
                AttachmentStrokeLengthLabel.Text = $"({range.Min} - {range.Max} мм)";
                CheckAttachmentStrokeLength();
            }
            catch
            {
                AttachmentStrokeWidthTextBox.BackColor = Color.Pink;
            }
        }

        //TODO: Дубли
        private void CheckAttachmentStrokeLength()
        {
            try
            {
                double attachmentStrokeLength = double.Parse(AttachmentStrokeLengthTextBox.Text);
                _guideParameters.AttachmentStrokeLength = attachmentStrokeLength;
                AttachmentStrokeLengthTextBox.BackColor = Color.White;
            }
            catch
            {
                AttachmentStrokeLengthTextBox.BackColor = Color.Pink;
            }
        }

        //TODO: Дубли
        private void GuideLengthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double guideLength = double.Parse(GuideLengthTextBox.Text);
                _guideParameters.GuideLength = guideLength;
                GuideLengthTextBox.BackColor = Color.White;
            }
            catch
            {
                GuideLengthTextBox.BackColor = Color.Pink;
            }
            ValidateAllValues();


        }

        //TODO: Дубли
        private void GuideWidthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double guideWidth = double.Parse(GuideWidthTextBox.Text);
                _guideParameters.GuideWidth = guideWidth;
                GuideWidthTextBox.BackColor = Color.White;
                Range range = _guideParameters.RangeDictionary[ParametersEnum.AttachmentStrokeWidth];
                AttachmentStrokeWidthLabel.Text = $"({range.Min} - {range.Max} мм)";
                CheckAttachmentStrokeWidth();
            }
            catch
            {
                GuideWidthTextBox.BackColor = Color.Pink;
            }

            ValidateAllValues();
        }

        private void AttachmentStrokeWidthTextBox_Leave(object sender, EventArgs e)
        {
            CheckAttachmentStrokeWidth();
            ValidateAllValues();
        }

        private void AttachmentStrokeLengthTextBox_Leave(object sender, EventArgs e)
        {
            CheckAttachmentStrokeLength();
            ValidateAllValues();
        }

        //TODO: Дубли
        private void GuideDepthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double guideDepth = double.Parse(GuideDepthTextBox.Text);
                _guideParameters.GuideDepth = guideDepth;
                GuideDepthTextBox.BackColor = Color.White;
            }
            catch
            {
                GuideDepthTextBox.BackColor = Color.Pink;
            }
            ValidateAllValues();
        }

        //TODO: Дубли
        private void HoleDiameterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double holdeDiameter = double.Parse(HoleDiameterTextBox.Text);
                _guideParameters.HoleDiameter = holdeDiameter;
                HoleDiameterTextBox.BackColor = Color.White;
            }
            catch
            {
                HoleDiameterTextBox.BackColor = Color.Pink;
            }
            ValidateAllValues();
        }

        //TODO: Дубли
        private void GuideAngleTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double guideAngle = double.Parse(GuideAngleTextBox.Text);
                _guideParameters.GuideAngle = guideAngle;
                GuideAngleTextBox.BackColor = Color.White;
            }
            catch
            {
                GuideAngleTextBox.BackColor = Color.Pink;
            }
            ValidateAllValues();
        }

        private void ValidateAllValues()
        {
            try
            {

                if (Validator.ValidateRange(double.Parse(GuideLengthTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.GuideLength].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.GuideLength].Max)
                    &&
                    Validator.ValidateRange(double.Parse(GuideWidthTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.GuideWidth].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.GuideWidth].Max)
                     &&
                    Validator.ValidateRange(double.Parse(GuideDepthTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.GuideDepth].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.GuideDepth].Max)
                    &&
                    Validator.ValidateRange(double.Parse(GuideAngleTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.GuideAngle].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.GuideAngle].Max)
                    &&
                    Validator.ValidateRange(double.Parse(HoleDiameterTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.HoleDiameter].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.HoleDiameter].Max)
                    &&
                    Validator.ValidateRange(double.Parse(AttachmentStrokeLengthTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.AttachmentStrokeLength].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.AttachmentStrokeLength].Max)
                    &&
                    Validator.ValidateRange(double.Parse(AttachmentStrokeWidthTextBox.Text),
                    _guideParameters.RangeDictionary[ParametersEnum.AttachmentStrokeWidth].Min,
                    _guideParameters.RangeDictionary[ParametersEnum.AttachmentStrokeWidth].Max)
                    )
                    BuildButton.Enabled = true;

                else BuildButton.Enabled = false;
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