
namespace GuideUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GuideLengthTextBox = new System.Windows.Forms.TextBox();
            this.GuideWidthTextBox = new System.Windows.Forms.TextBox();
            this.GuideDepthTextBox = new System.Windows.Forms.TextBox();
            this.HoleDiameterTextBox = new System.Windows.Forms.TextBox();
            this.AttachmentStrokeWidthTextBox = new System.Windows.Forms.TextBox();
            this.AttachmentStrokeLengthTextBox = new System.Windows.Forms.TextBox();
            this.GuideAngleTextBox = new System.Windows.Forms.TextBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GuideWidthLabel = new System.Windows.Forms.Label();
            this.AttachmentStrokeLengthLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AttachmentStrokeWidthLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GuideLengthTextBox
            // 
            this.GuideLengthTextBox.BackColor = System.Drawing.Color.White;
            this.GuideLengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuideLengthTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GuideLengthTextBox.Location = new System.Drawing.Point(256, 2);
            this.GuideLengthTextBox.Name = "GuideLengthTextBox";
            this.GuideLengthTextBox.Size = new System.Drawing.Size(93, 26);
            this.GuideLengthTextBox.TabIndex = 0;
            this.GuideLengthTextBox.Text = "50";
            this.GuideLengthTextBox.Enter += new System.EventHandler(this.GuideLengthTextBox_Enter);
            this.GuideLengthTextBox.Leave += new System.EventHandler(this.GuideLengthTextBox_Leave);
            // 
            // GuideWidthTextBox
            // 
            this.GuideWidthTextBox.BackColor = System.Drawing.Color.White;
            this.GuideWidthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuideWidthTextBox.Location = new System.Drawing.Point(256, 34);
            this.GuideWidthTextBox.Name = "GuideWidthTextBox";
            this.GuideWidthTextBox.Size = new System.Drawing.Size(93, 26);
            this.GuideWidthTextBox.TabIndex = 1;
            this.GuideWidthTextBox.Text = "10";
            this.GuideWidthTextBox.Enter += new System.EventHandler(this.GuideWidthTextBox_Enter);
            this.GuideWidthTextBox.Leave += new System.EventHandler(this.GuideWidthTextBox_Leave);
            // 
            // GuideDepthTextBox
            // 
            this.GuideDepthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuideDepthTextBox.Location = new System.Drawing.Point(256, 66);
            this.GuideDepthTextBox.Name = "GuideDepthTextBox";
            this.GuideDepthTextBox.Size = new System.Drawing.Size(93, 26);
            this.GuideDepthTextBox.TabIndex = 2;
            this.GuideDepthTextBox.Text = "5";
            this.GuideDepthTextBox.Enter += new System.EventHandler(this.GuideDepthTextBox_Enter);
            this.GuideDepthTextBox.Leave += new System.EventHandler(this.GuideDepthTextBox_Leave);
            // 
            // HoleDiameterTextBox
            // 
            this.HoleDiameterTextBox.BackColor = System.Drawing.Color.White;
            this.HoleDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HoleDiameterTextBox.Location = new System.Drawing.Point(256, 162);
            this.HoleDiameterTextBox.Name = "HoleDiameterTextBox";
            this.HoleDiameterTextBox.Size = new System.Drawing.Size(93, 26);
            this.HoleDiameterTextBox.TabIndex = 5;
            this.HoleDiameterTextBox.Text = "2";
            this.HoleDiameterTextBox.Enter += new System.EventHandler(this.HoleDiameterTextBox_Enter);
            this.HoleDiameterTextBox.Leave += new System.EventHandler(this.HoleDiameterTextBox_Leave);
            // 
            // AttachmentStrokeWidthTextBox
            // 
            this.AttachmentStrokeWidthTextBox.BackColor = System.Drawing.Color.White;
            this.AttachmentStrokeWidthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachmentStrokeWidthTextBox.Location = new System.Drawing.Point(256, 130);
            this.AttachmentStrokeWidthTextBox.Name = "AttachmentStrokeWidthTextBox";
            this.AttachmentStrokeWidthTextBox.Size = new System.Drawing.Size(93, 26);
            this.AttachmentStrokeWidthTextBox.TabIndex = 4;
            this.AttachmentStrokeWidthTextBox.Text = "3";
            this.AttachmentStrokeWidthTextBox.Enter += new System.EventHandler(this.AttachmentStrokeWidthTextBox_Enter);
            this.AttachmentStrokeWidthTextBox.Leave += new System.EventHandler(this.AttachmentStrokeWidthTextBox_Leave);
            // 
            // AttachmentStrokeLengthTextBox
            // 
            this.AttachmentStrokeLengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachmentStrokeLengthTextBox.Location = new System.Drawing.Point(256, 98);
            this.AttachmentStrokeLengthTextBox.Name = "AttachmentStrokeLengthTextBox";
            this.AttachmentStrokeLengthTextBox.Size = new System.Drawing.Size(93, 26);
            this.AttachmentStrokeLengthTextBox.TabIndex = 3;
            this.AttachmentStrokeLengthTextBox.Text = "15";
            this.AttachmentStrokeLengthTextBox.Enter += new System.EventHandler(this.AttachmentStrokeLengthTextBox_Enter);
            this.AttachmentStrokeLengthTextBox.Leave += new System.EventHandler(this.AttachmentStrokeLengthTextBox_Leave);
            // 
            // GuideAngleTextBox
            // 
            this.GuideAngleTextBox.BackColor = System.Drawing.Color.White;
            this.GuideAngleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuideAngleTextBox.Location = new System.Drawing.Point(256, 194);
            this.GuideAngleTextBox.Name = "GuideAngleTextBox";
            this.GuideAngleTextBox.Size = new System.Drawing.Size(93, 26);
            this.GuideAngleTextBox.TabIndex = 6;
            this.GuideAngleTextBox.Text = "65";
            this.GuideAngleTextBox.Enter += new System.EventHandler(this.GuideAngleTextBox_Enter);
            this.GuideAngleTextBox.Leave += new System.EventHandler(this.GuideAngleTextBox_Leave);
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(256, 230);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(93, 30);
            this.BuildButton.TabIndex = 7;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Толщина направляющей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ширина направляющей";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Длина направляющей";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Угол наклона направляющей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Длина хода крепления";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ширина хода крепления";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Диаметр отверстия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(355, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "(50 - 150 мм)";
            // 
            // GuideWidthLabel
            // 
            this.GuideWidthLabel.AutoSize = true;
            this.GuideWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuideWidthLabel.Location = new System.Drawing.Point(355, 40);
            this.GuideWidthLabel.Name = "GuideWidthLabel";
            this.GuideWidthLabel.Size = new System.Drawing.Size(94, 20);
            this.GuideWidthLabel.TabIndex = 17;
            this.GuideWidthLabel.Text = "(10 - 30 мм)";
            // 
            // AttachmentStrokeLengthLabel
            // 
            this.AttachmentStrokeLengthLabel.AutoSize = true;
            this.AttachmentStrokeLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachmentStrokeLengthLabel.Location = new System.Drawing.Point(355, 104);
            this.AttachmentStrokeLengthLabel.Name = "AttachmentStrokeLengthLabel";
            this.AttachmentStrokeLengthLabel.Size = new System.Drawing.Size(94, 20);
            this.AttachmentStrokeLengthLabel.TabIndex = 19;
            this.AttachmentStrokeLengthLabel.Text = "(15 - 90 мм)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(355, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "(5 - 20 мм)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(355, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "(2 - 20 мм)";
            // 
            // AttachmentStrokeWidthLabel
            // 
            this.AttachmentStrokeWidthLabel.AutoSize = true;
            this.AttachmentStrokeWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachmentStrokeWidthLabel.Location = new System.Drawing.Point(355, 136);
            this.AttachmentStrokeWidthLabel.Name = "AttachmentStrokeWidthLabel";
            this.AttachmentStrokeWidthLabel.Size = new System.Drawing.Size(76, 20);
            this.AttachmentStrokeWidthLabel.TabIndex = 20;
            this.AttachmentStrokeWidthLabel.Text = "(3 - 5 мм)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(355, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "(65 - 270°)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GuideUI.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(501, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 264);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AttachmentStrokeWidthLabel);
            this.Controls.Add(this.AttachmentStrokeLengthLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GuideWidthLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.GuideAngleTextBox);
            this.Controls.Add(this.HoleDiameterTextBox);
            this.Controls.Add(this.AttachmentStrokeWidthTextBox);
            this.Controls.Add(this.AttachmentStrokeLengthTextBox);
            this.Controls.Add(this.GuideDepthTextBox);
            this.Controls.Add(this.GuideWidthTextBox);
            this.Controls.Add(this.GuideLengthTextBox);
            this.Name = "MainForm";
            this.Text = "Направляющая";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GuideLengthTextBox;
        private System.Windows.Forms.TextBox GuideWidthTextBox;
        private System.Windows.Forms.TextBox GuideDepthTextBox;
        private System.Windows.Forms.TextBox HoleDiameterTextBox;
        private System.Windows.Forms.TextBox AttachmentStrokeWidthTextBox;
        private System.Windows.Forms.TextBox AttachmentStrokeLengthTextBox;
        private System.Windows.Forms.TextBox GuideAngleTextBox;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label GuideWidthLabel;
        private System.Windows.Forms.Label AttachmentStrokeLengthLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label AttachmentStrokeWidthLabel;
        private System.Windows.Forms.Label label14;
    }
}

