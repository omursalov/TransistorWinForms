namespace TransistorWinForms
{
    public partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            transitionType1 = new RadioButton();
            transitionType2 = new RadioButton();
            circleCheckBox = new CheckBox();
            label4 = new Label();
            cxTextBox = new TextBox();
            cyTextBox = new TextBox();
            label5 = new Label();
            widthTextBox = new TextBox();
            label6 = new Label();
            mSizeTextBox = new TextBox();
            SaveAsBtn = new Button();
            iniLoadBtn = new Button();
            colorLineCB = new ComboBox();
            fillColorCB = new ComboBox();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainPictureBox
            // 
            mainPictureBox.BorderStyle = BorderStyle.FixedSingle;
            mainPictureBox.Location = new Point(468, 12);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(500, 500);
            mainPictureBox.TabIndex = 0;
            mainPictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 1;
            label1.Text = "Цвет линии";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 2;
            label2.Text = "Цвет заливки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 3;
            label3.Text = "Тип транзистора";
            // 
            // transitionType1
            // 
            transitionType1.AutoSize = true;
            transitionType1.Location = new Point(12, 149);
            transitionType1.Name = "transitionType1";
            transitionType1.Size = new Size(121, 24);
            transitionType1.TabIndex = 4;
            transitionType1.TabStop = true;
            transitionType1.Text = "n-канальный";
            transitionType1.UseVisualStyleBackColor = true;
            transitionType1.CheckedChanged += transitionType1_CheckedChanged;
            // 
            // transitionType2
            // 
            transitionType2.AutoSize = true;
            transitionType2.Location = new Point(12, 179);
            transitionType2.Name = "transitionType2";
            transitionType2.Size = new Size(122, 24);
            transitionType2.TabIndex = 5;
            transitionType2.TabStop = true;
            transitionType2.Text = "p-канальный";
            transitionType2.UseVisualStyleBackColor = true;
            transitionType2.CheckedChanged += transitionType2_CheckedChanged;
            // 
            // circleCheckBox
            // 
            circleCheckBox.AutoSize = true;
            circleCheckBox.Location = new Point(12, 209);
            circleCheckBox.Name = "circleCheckBox";
            circleCheckBox.Size = new Size(113, 24);
            circleCheckBox.TabIndex = 6;
            circleCheckBox.Text = "окружность";
            circleCheckBox.UseVisualStyleBackColor = true;
            circleCheckBox.CheckedChanged += circleCheckBox_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 12);
            label4.Name = "label4";
            label4.Size = new Size(149, 20);
            label4.TabIndex = 7;
            label4.Text = "Координаты центра";
            // 
            // cxTextBox
            // 
            cxTextBox.Location = new Point(217, 44);
            cxTextBox.Name = "cxTextBox";
            cxTextBox.Size = new Size(96, 27);
            cxTextBox.TabIndex = 8;
            cxTextBox.TextChanged += cxTextBox_TextChanged;
            cxTextBox.KeyPress += textBox_KeyPressOnlyDigits;
            // 
            // cyTextBox
            // 
            cyTextBox.Location = new Point(319, 44);
            cyTextBox.Name = "cyTextBox";
            cyTextBox.Size = new Size(94, 27);
            cyTextBox.TabIndex = 9;
            cyTextBox.TextChanged += cyTextBox_TextChanged;
            cyTextBox.KeyPress += textBox_KeyPressOnlyDigits;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 110);
            label5.Name = "label5";
            label5.Size = new Size(115, 20);
            label5.TabIndex = 10;
            label5.Text = "Ширина линии";
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new Point(338, 107);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new Size(75, 27);
            widthTextBox.TabIndex = 11;
            widthTextBox.TextChanged += widthTextBox_TextChanged;
            widthTextBox.KeyPress += textBox_KeyPressOnlyDigits;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(217, 153);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 12;
            label6.Text = "Размер M";
            // 
            // mSizeTextBox
            // 
            mSizeTextBox.Location = new Point(338, 148);
            mSizeTextBox.Name = "mSizeTextBox";
            mSizeTextBox.Size = new Size(75, 27);
            mSizeTextBox.TabIndex = 13;
            mSizeTextBox.TextChanged += mSizeTextBox_TextChanged;
            mSizeTextBox.KeyPress += textBox_KeyPressOnlyDigits;
            // 
            // SaveAsBtn
            // 
            SaveAsBtn.Location = new Point(12, 289);
            SaveAsBtn.Name = "SaveAsBtn";
            SaveAsBtn.Size = new Size(282, 29);
            SaveAsBtn.TabIndex = 15;
            SaveAsBtn.Text = "Сохранить как";
            SaveAsBtn.UseVisualStyleBackColor = true;
            SaveAsBtn.Click += SaveAsBtn_Click;
            // 
            // iniLoadBtn
            // 
            iniLoadBtn.Location = new Point(12, 335);
            iniLoadBtn.Name = "iniLoadBtn";
            iniLoadBtn.Size = new Size(282, 35);
            iniLoadBtn.TabIndex = 17;
            iniLoadBtn.Text = "Подгрузить состояние";
            iniLoadBtn.UseVisualStyleBackColor = true;
            iniLoadBtn.Click += iniLoadBtn_Click;
            // 
            // colorLineCB
            // 
            colorLineCB.FormattingEnabled = true;
            colorLineCB.Location = new Point(12, 37);
            colorLineCB.Name = "colorLineCB";
            colorLineCB.Size = new Size(163, 28);
            colorLineCB.TabIndex = 19;
            colorLineCB.SelectedIndexChanged += colorLineCB_SelectedIndexChanged;
            // 
            // fillColorCB
            // 
            fillColorCB.FormattingEnabled = true;
            fillColorCB.Location = new Point(12, 95);
            fillColorCB.Name = "fillColorCB";
            fillColorCB.Size = new Size(163, 28);
            fillColorCB.TabIndex = 20;
            fillColorCB.SelectedIndexChanged += fillColorCB_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 387);
            button1.Name = "button1";
            button1.Size = new Size(282, 32);
            button1.TabIndex = 21;
            button1.Text = "Откатить до default";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(468, 515);
            label7.Name = "label7";
            label7.Size = new Size(17, 20);
            label7.TabIndex = 22;
            label7.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(429, 9);
            label8.Name = "label8";
            label8.Size = new Size(33, 20);
            label8.TabIndex = 23;
            label8.Text = "100";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(935, 515);
            label9.Name = "label9";
            label9.Size = new Size(33, 20);
            label9.TabIndex = 24;
            label9.Text = "100";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(217, 68);
            label10.Name = "label10";
            label10.Size = new Size(23, 20);
            label10.TabIndex = 25;
            label10.Text = "cx";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(319, 68);
            label11.Name = "label11";
            label11.Size = new Size(23, 20);
            label11.TabIndex = 26;
            label11.Text = "cy";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 545);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(fillColorCB);
            Controls.Add(colorLineCB);
            Controls.Add(iniLoadBtn);
            Controls.Add(SaveAsBtn);
            Controls.Add(mSizeTextBox);
            Controls.Add(label6);
            Controls.Add(widthTextBox);
            Controls.Add(label5);
            Controls.Add(cyTextBox);
            Controls.Add(cxTextBox);
            Controls.Add(label4);
            Controls.Add(circleCheckBox);
            Controls.Add(transitionType2);
            Controls.Add(transitionType1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mainPictureBox);
            Name = "MainForm";
            Text = "Курсовая C#";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        public PictureBox mainPictureBox;
        public Label label1;
        public Label label2;
        public Label label3;
        public RadioButton transitionType1;
        public RadioButton transitionType2;
        public CheckBox circleCheckBox;
        public Label label4;
        public TextBox cxTextBox;
        public TextBox cyTextBox;
        public Label label5;
        public TextBox widthTextBox;
        public Label label6;
        public TextBox mSizeTextBox;
        public Button SaveAsBtn;
        public Button iniLoadBtn;
        public ComboBox colorLineCB;
        public ComboBox fillColorCB;
        public Button button1;
        private Label label7;
        private Label label8;
        private Label label9;
        public Label label10;
        public Label label11;
    }
}
