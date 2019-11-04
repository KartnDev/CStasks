namespace STP_Task3_WinForm_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComputeButton = new System.Windows.Forms.Button();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.TextTaskLable = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultOutputLable = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Radius});
            this.dataGridView1.Location = new System.Drawing.Point(567, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(212, 207);
            this.dataGridView1.TabIndex = 0;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 50;
            // 
            // Radius
            // 
            this.Radius.HeaderText = "Radius";
            this.Radius.Name = "Radius";
            this.Radius.Width = 50;
            // 
            // ComputeButton
            // 
            this.ComputeButton.Location = new System.Drawing.Point(457, 12);
            this.ComputeButton.Name = "ComputeButton";
            this.ComputeButton.Size = new System.Drawing.Size(104, 39);
            this.ComputeButton.TabIndex = 2;
            this.ComputeButton.Text = "Compute";
            this.ComputeButton.UseVisualStyleBackColor = true;
            this.ComputeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Location = new System.Drawing.Point(12, 12);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(58, 13);
            this.TaskLabel.TabIndex = 3;
            this.TaskLabel.Text = "Task Text:";
            // 
            // TextTaskLable
            // 
            this.TextTaskLable.AutoSize = true;
            this.TextTaskLable.Location = new System.Drawing.Point(12, 36);
            this.TextTaskLable.Name = "TextTaskLable";
            this.TextTaskLable.Size = new System.Drawing.Size(392, 156);
            this.TextTaskLable.TabIndex = 4;
            this.TextTaskLable.Text = resources.GetString("TextTaskLable.Text");
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(454, 111);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(40, 13);
            this.ResultLabel.TabIndex = 5;
            this.ResultLabel.Text = "Result:";
            // 
            // ResultOutputLable
            // 
            this.ResultOutputLable.AutoSize = true;
            this.ResultOutputLable.Location = new System.Drawing.Point(454, 141);
            this.ResultOutputLable.Name = "ResultOutputLable";
            this.ResultOutputLable.Size = new System.Drawing.Size(16, 13);
            this.ResultOutputLable.TabIndex = 6;
            this.ResultOutputLable.Text = "...";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(457, 57);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(104, 39);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear Text";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 450);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ResultOutputLable);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.TextTaskLable);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.ComputeButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radius;
        private System.Windows.Forms.Button ComputeButton;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.Label TextTaskLable;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label ResultOutputLable;
        private System.Windows.Forms.Button ClearButton;
    }
}

