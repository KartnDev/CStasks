namespace STP_Task4
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.textlabel = new System.Windows.Forms.Label();
            this.TransformButton = new System.Windows.Forms.Button();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 37);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(227, 142);
            this.InputTextBox.TabIndex = 0;
            // 
            // textlabel
            // 
            this.textlabel.AutoSize = true;
            this.textlabel.Location = new System.Drawing.Point(12, 13);
            this.textlabel.Name = "textlabel";
            this.textlabel.Size = new System.Drawing.Size(55, 13);
            this.textlabel.TabIndex = 1;
            this.textlabel.Text = "TextInput:";
            // 
            // TransformButton
            // 
            this.TransformButton.Location = new System.Drawing.Point(12, 185);
            this.TransformButton.Name = "TransformButton";
            this.TransformButton.Size = new System.Drawing.Size(118, 48);
            this.TransformButton.TabIndex = 2;
            this.TransformButton.Text = "Transform";
            this.TransformButton.UseVisualStyleBackColor = true;
            this.TransformButton.Click += new System.EventHandler(this.TransformButton_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(260, 13);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(72, 13);
            this.ResultLabel.TabIndex = 4;
            this.ResultLabel.Text = "ResultOutput:";
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(260, 37);
            this.ResultBox.Multiline = true;
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(227, 142);
            this.ResultBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "1. Дана строка. Напечатать слова в нее входящие,\r\n но в обратном порядке \r\n(снача" +
    "ла последнее, потом предпоследнее и т.д.).";
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Location = new System.Drawing.Point(520, 13);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(55, 13);
            this.TaskLabel.TabIndex = 6;
            this.TaskLabel.Text = "TaskText:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.TransformButton);
            this.Controls.Add(this.textlabel);
            this.Controls.Add(this.InputTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label textlabel;
        private System.Windows.Forms.Button TransformButton;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TaskLabel;
    }
}

