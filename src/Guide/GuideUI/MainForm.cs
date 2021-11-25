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
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _kompasConnector = new KompasConnector();
            _kompasConnector.ConnectToKompas();
        }

        private void GuideLengthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _guideParameters.GuideLength = 5;
            }
            catch
            {
                GuideLengthTextBox.Text = "Проверка ошибки";
            }
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
