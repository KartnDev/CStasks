namespace WindowsFormsApp1
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RenderButton = new System.Windows.Forms.Button();
            this.AxisRotationComboBox = new System.Windows.Forms.ComboBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.solidComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.coeffBox = new System.Windows.Forms.TextBox();
            this.angelBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.shiftZBox = new System.Windows.Forms.TextBox();
            this.shiftXBox = new System.Windows.Forms.TextBox();
            this.shiftYBox = new System.Windows.Forms.TextBox();
            this.scaleBoxFy = new System.Windows.Forms.TextBox();
            this.scaleBoxFx = new System.Windows.Forms.TextBox();
            this.scaleBoxFz = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.vectorYBox = new System.Windows.Forms.TextBox();
            this.vectorXBox = new System.Windows.Forms.TextBox();
            this.vectorZBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.angularFrequencyBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(649, 541);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Canvas";
            // 
            // RenderButton
            // 
            this.RenderButton.Location = new System.Drawing.Point(668, 13);
            this.RenderButton.Name = "RenderButton";
            this.RenderButton.Size = new System.Drawing.Size(120, 47);
            this.RenderButton.TabIndex = 2;
            this.RenderButton.Text = "Render";
            this.RenderButton.UseVisualStyleBackColor = true;
            this.RenderButton.Click += new System.EventHandler(this.RenderButton_Click);
            // 
            // AxisRotationComboBox
            // 
            this.AxisRotationComboBox.FormattingEnabled = true;
            this.AxisRotationComboBox.Items.AddRange(new object[] {
            "None",
            "OX",
            "OY",
            "OZ",
            "OXY",
            "OZY",
            "OZX",
            "OXYZ",
            "Vectorized"});
            this.AxisRotationComboBox.Location = new System.Drawing.Point(668, 180);
            this.AxisRotationComboBox.Name = "AxisRotationComboBox";
            this.AxisRotationComboBox.Size = new System.Drawing.Size(120, 21);
            this.AxisRotationComboBox.TabIndex = 3;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(668, 66);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(120, 47);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // solidComboBox
            // 
            this.solidComboBox.FormattingEnabled = true;
            this.solidComboBox.Items.AddRange(new object[] {
            "Tetrahedron",
            "Hexahedron",
            "Octahedron",
            "Icosahedron",
            "Dodecahedron"});
            this.solidComboBox.Location = new System.Drawing.Point(668, 136);
            this.solidComboBox.Name = "solidComboBox";
            this.solidComboBox.Size = new System.Drawing.Size(120, 21);
            this.solidComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SolidName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(669, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Axis Rotation:";
            // 
            // coeffBox
            // 
            this.coeffBox.Location = new System.Drawing.Point(668, 381);
            this.coeffBox.Name = "coeffBox";
            this.coeffBox.Size = new System.Drawing.Size(58, 20);
            this.coeffBox.TabIndex = 8;
            this.coeffBox.Text = "0,6";
            // 
            // angelBox
            // 
            this.angelBox.Location = new System.Drawing.Point(730, 381);
            this.angelBox.Name = "angelBox";
            this.angelBox.Size = new System.Drawing.Size(58, 20);
            this.angelBox.TabIndex = 9;
            this.angelBox.Text = "0,7853";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(669, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Coef:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(727, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Angle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(669, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Projection params:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(669, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Shift (x,y,z):";
            // 
            // shiftZBox
            // 
            this.shiftZBox.Location = new System.Drawing.Point(752, 432);
            this.shiftZBox.Name = "shiftZBox";
            this.shiftZBox.Size = new System.Drawing.Size(36, 20);
            this.shiftZBox.TabIndex = 14;
            this.shiftZBox.Text = "200";
            // 
            // shiftXBox
            // 
            this.shiftXBox.Location = new System.Drawing.Point(668, 432);
            this.shiftXBox.Name = "shiftXBox";
            this.shiftXBox.Size = new System.Drawing.Size(36, 20);
            this.shiftXBox.TabIndex = 15;
            this.shiftXBox.Text = "200";
            // 
            // shiftYBox
            // 
            this.shiftYBox.Location = new System.Drawing.Point(710, 432);
            this.shiftYBox.Name = "shiftYBox";
            this.shiftYBox.Size = new System.Drawing.Size(36, 20);
            this.shiftYBox.TabIndex = 16;
            this.shiftYBox.Text = "200";
            // 
            // scaleBoxFy
            // 
            this.scaleBoxFy.Location = new System.Drawing.Point(710, 515);
            this.scaleBoxFy.Name = "scaleBoxFy";
            this.scaleBoxFy.Size = new System.Drawing.Size(36, 20);
            this.scaleBoxFy.TabIndex = 20;
            this.scaleBoxFy.Text = "0,5";
            // 
            // scaleBoxFx
            // 
            this.scaleBoxFx.Location = new System.Drawing.Point(668, 515);
            this.scaleBoxFx.Name = "scaleBoxFx";
            this.scaleBoxFx.Size = new System.Drawing.Size(36, 20);
            this.scaleBoxFx.TabIndex = 19;
            this.scaleBoxFx.Text = "0,5";
            // 
            // scaleBoxFz
            // 
            this.scaleBoxFz.Location = new System.Drawing.Point(752, 515);
            this.scaleBoxFz.Name = "scaleBoxFz";
            this.scaleBoxFz.Size = new System.Drawing.Size(36, 20);
            this.scaleBoxFz.TabIndex = 18;
            this.scaleBoxFz.Text = "0,1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(665, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Scale (fx,fy,fz):";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(668, 492);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "NoScale";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // vectorYBox
            // 
            this.vectorYBox.Location = new System.Drawing.Point(710, 220);
            this.vectorYBox.Name = "vectorYBox";
            this.vectorYBox.Size = new System.Drawing.Size(36, 20);
            this.vectorYBox.TabIndex = 25;
            this.vectorYBox.Text = "0,331";
            // 
            // vectorXBox
            // 
            this.vectorXBox.Location = new System.Drawing.Point(668, 220);
            this.vectorXBox.Name = "vectorXBox";
            this.vectorXBox.Size = new System.Drawing.Size(36, 20);
            this.vectorXBox.TabIndex = 24;
            this.vectorXBox.Text = "0,5";
            // 
            // vectorZBox
            // 
            this.vectorZBox.Location = new System.Drawing.Point(752, 220);
            this.vectorZBox.Name = "vectorZBox";
            this.vectorZBox.Size = new System.Drawing.Size(36, 20);
            this.vectorZBox.TabIndex = 23;
            this.vectorZBox.Text = "0,8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(669, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Unit Vector of Rotation (x,y,z):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(669, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "angular frequency:";
            // 
            // angularFrequencyBox
            // 
            this.angularFrequencyBox.Location = new System.Drawing.Point(668, 268);
            this.angularFrequencyBox.Name = "angularFrequencyBox";
            this.angularFrequencyBox.Size = new System.Drawing.Size(120, 20);
            this.angularFrequencyBox.TabIndex = 26;
            this.angularFrequencyBox.Text = "0,6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 566);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.angularFrequencyBox);
            this.Controls.Add(this.vectorYBox);
            this.Controls.Add(this.vectorXBox);
            this.Controls.Add(this.vectorZBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.scaleBoxFy);
            this.Controls.Add(this.scaleBoxFx);
            this.Controls.Add(this.scaleBoxFz);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.shiftYBox);
            this.Controls.Add(this.shiftXBox);
            this.Controls.Add(this.shiftZBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.angelBox);
            this.Controls.Add(this.coeffBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.solidComboBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.AxisRotationComboBox);
            this.Controls.Add(this.RenderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Graphics Application!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RenderButton;
        private System.Windows.Forms.ComboBox AxisRotationComboBox;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ComboBox solidComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox coeffBox;
        private System.Windows.Forms.TextBox angelBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox shiftZBox;
        private System.Windows.Forms.TextBox shiftXBox;
        private System.Windows.Forms.TextBox shiftYBox;
        private System.Windows.Forms.TextBox scaleBoxFy;
        private System.Windows.Forms.TextBox scaleBoxFx;
        private System.Windows.Forms.TextBox scaleBoxFz;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox vectorYBox;
        private System.Windows.Forms.TextBox vectorXBox;
        private System.Windows.Forms.TextBox vectorZBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox angularFrequencyBox;
    }
}

