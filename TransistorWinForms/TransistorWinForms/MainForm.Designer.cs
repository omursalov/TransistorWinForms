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
            bmpSaveBtn = new Button();
            SaveAsBtn = new Button();
            iniSaveBtn = new Button();
            iniLoadBtn = new Button();
            setDefaultBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainPictureBox
            // 
            mainPictureBox.Location = new Point(468, 12);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(795, 608);
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
            // 
            // cyTextBox
            // 
            cyTextBox.Location = new Point(319, 44);
            cyTextBox.Name = "cyTextBox";
            cyTextBox.Size = new Size(94, 27);
            cyTextBox.TabIndex = 9;
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
            // 
            // bmpSaveBtn
            // 
            bmpSaveBtn.Location = new Point(12, 265);
            bmpSaveBtn.Name = "bmpSaveBtn";
            bmpSaveBtn.Size = new Size(197, 29);
            bmpSaveBtn.TabIndex = 14;
            bmpSaveBtn.Text = "Сохранить BMP";
            bmpSaveBtn.UseVisualStyleBackColor = true;
            // 
            // SaveAsBtn
            // 
            SaveAsBtn.Location = new Point(12, 300);
            SaveAsBtn.Name = "SaveAsBtn";
            SaveAsBtn.Size = new Size(197, 29);
            SaveAsBtn.TabIndex = 15;
            SaveAsBtn.Text = "Сохранить как";
            SaveAsBtn.UseVisualStyleBackColor = true;
            // 
            // iniSaveBtn
            // 
            iniSaveBtn.Location = new Point(12, 387);
            iniSaveBtn.Name = "iniSaveBtn";
            iniSaveBtn.Size = new Size(197, 29);
            iniSaveBtn.TabIndex = 16;
            iniSaveBtn.Text = "Сохранить INI";
            iniSaveBtn.UseVisualStyleBackColor = true;
            // 
            // iniLoadBtn
            // 
            iniLoadBtn.Location = new Point(12, 422);
            iniLoadBtn.Name = "iniLoadBtn";
            iniLoadBtn.Size = new Size(197, 29);
            iniLoadBtn.TabIndex = 17;
            iniLoadBtn.Text = "Подгрузить INI";
            iniLoadBtn.UseVisualStyleBackColor = true;
            // 
            // setDefaultBtn
            // 
            setDefaultBtn.Location = new Point(12, 335);
            setDefaultBtn.Name = "setDefaultBtn";
            setDefaultBtn.Size = new Size(197, 36);
            setDefaultBtn.TabIndex = 18;
            setDefaultBtn.Text = "Значения по умолчанию";
            setDefaultBtn.UseVisualStyleBackColor = true;
            setDefaultBtn.Click += setDefaultBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 632);
            Controls.Add(setDefaultBtn);
            Controls.Add(iniLoadBtn);
            Controls.Add(iniSaveBtn);
            Controls.Add(SaveAsBtn);
            Controls.Add(bmpSaveBtn);
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
        public Button bmpSaveBtn;
        public Button SaveAsBtn;
        public Button iniSaveBtn;
        public Button iniLoadBtn;
        private Button setDefaultBtn;
    }
}
