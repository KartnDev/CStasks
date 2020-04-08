namespace NumMethods1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.canvasTextlabel = new System.Windows.Forms.Label();
            this.renderButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasBox
            // 
            this.canvasBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasBox.Location = new System.Drawing.Point(12, 12);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(671, 426);
            this.canvasBox.TabIndex = 0;
            this.canvasBox.TabStop = false;
            // 
            // canvasTextlabel
            // 
            this.canvasTextlabel.AutoSize = true;
            this.canvasTextlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasTextlabel.Location = new System.Drawing.Point(12, 12);
            this.canvasTextlabel.Name = "canvasTextlabel";
            this.canvasTextlabel.Size = new System.Drawing.Size(45, 15);
            this.canvasTextlabel.TabIndex = 1;
            this.canvasTextlabel.Text = "Canvas";
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(690, 13);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(98, 46);
            this.renderButton.TabIndex = 2;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.RenderButtonOnClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Lagruange",
            "Newton"});
            this.comboBox1.Location = new System.Drawing.Point(690, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(690, 104);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(98, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 16;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.canvasTextlabel);
            this.Controls.Add(this.canvasBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasBox;
        private System.Windows.Forms.Label canvasTextlabel;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

