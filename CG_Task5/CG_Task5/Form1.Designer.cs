﻿namespace CG_Task5
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
            this.GraphicsBox = new System.Windows.Forms.PictureBox();
            this.RenderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphicsBox
            // 
            this.GraphicsBox.Location = new System.Drawing.Point(0, 0);
            this.GraphicsBox.Name = "GraphicsBox";
            this.GraphicsBox.Size = new System.Drawing.Size(866, 573);
            this.GraphicsBox.TabIndex = 0;
            this.GraphicsBox.TabStop = false;
            // 
            // RenderButton
            // 
            this.RenderButton.Location = new System.Drawing.Point(873, 13);
            this.RenderButton.Name = "RenderButton";
            this.RenderButton.Size = new System.Drawing.Size(114, 45);
            this.RenderButton.TabIndex = 1;
            this.RenderButton.Text = "Render";
            this.RenderButton.UseVisualStyleBackColor = true;
            this.RenderButton.Click += new System.EventHandler(this.RenderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 572);
            this.Controls.Add(this.RenderButton);
            this.Controls.Add(this.GraphicsBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphicsBox;
        private System.Windows.Forms.Button RenderButton;
    }
}

