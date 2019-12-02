namespace STP_Task5_Winform
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vlaue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppendButton = new System.Windows.Forms.Button();
            this.InputValueBox = new System.Windows.Forms.TextBox();
            this.InputKeyBox = new System.Windows.Forms.TextBox();
            this.FillButton = new System.Windows.Forms.Button();
            this.InputDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClearButton = new System.Windows.Forms.Button();
            this.FillRandom = new System.Windows.Forms.Button();
            this.FillFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FillFromDataGridButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Vlaue});
            this.dataGridView.Location = new System.Drawing.Point(805, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(240, 426);
            this.dataGridView.TabIndex = 0;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            // 
            // Vlaue
            // 
            this.Vlaue.HeaderText = "Value";
            this.Vlaue.Name = "Vlaue";
            // 
            // AppendButton
            // 
            this.AppendButton.Location = new System.Drawing.Point(416, 12);
            this.AppendButton.Name = "AppendButton";
            this.AppendButton.Size = new System.Drawing.Size(100, 46);
            this.AppendButton.TabIndex = 1;
            this.AppendButton.Text = "Append K-V";
            this.AppendButton.UseVisualStyleBackColor = true;
            this.AppendButton.Click += new System.EventHandler(this.AppendKeyValueButton_Click);
            // 
            // InputValueBox
            // 
            this.InputValueBox.Location = new System.Drawing.Point(310, 38);
            this.InputValueBox.Name = "InputValueBox";
            this.InputValueBox.Size = new System.Drawing.Size(100, 20);
            this.InputValueBox.TabIndex = 2;
            // 
            // InputKeyBox
            // 
            this.InputKeyBox.Location = new System.Drawing.Point(310, 12);
            this.InputKeyBox.Name = "InputKeyBox";
            this.InputKeyBox.Size = new System.Drawing.Size(100, 20);
            this.InputKeyBox.TabIndex = 3;
            // 
            // FillButton
            // 
            this.FillButton.Location = new System.Drawing.Point(707, 12);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(92, 67);
            this.FillButton.TabIndex = 4;
            this.FillButton.Text = "FillDataGridFromHash";
            this.FillButton.UseVisualStyleBackColor = true;
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // InputDataGridView
            // 
            this.InputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.InputDataGridView.Location = new System.Drawing.Point(12, 12);
            this.InputDataGridView.Name = "InputDataGridView";
            this.InputDataGridView.Size = new System.Drawing.Size(240, 426);
            this.InputDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Key";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(707, 85);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(92, 46);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear All";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // FillRandom
            // 
            this.FillRandom.Location = new System.Drawing.Point(118, 444);
            this.FillRandom.Name = "FillRandom";
            this.FillRandom.Size = new System.Drawing.Size(100, 46);
            this.FillRandom.TabIndex = 7;
            this.FillRandom.Text = "Fill Random ";
            this.FillRandom.UseVisualStyleBackColor = true;
            this.FillRandom.Click += new System.EventHandler(this.FillRandom_Click);
            // 
            // FillFileButton
            // 
            this.FillFileButton.Location = new System.Drawing.Point(12, 444);
            this.FillFileButton.Name = "FillFileButton";
            this.FillFileButton.Size = new System.Drawing.Size(100, 46);
            this.FillFileButton.TabIndex = 8;
            this.FillFileButton.Text = "Fill From File";
            this.FillFileButton.UseVisualStyleBackColor = true;
            this.FillFileButton.Click += new System.EventHandler(this.FillFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Value:";
            // 
            // FillFromDataGridButton
            // 
            this.FillFromDataGridButton.Location = new System.Drawing.Point(272, 85);
            this.FillFromDataGridButton.Name = "FillFromDataGridButton";
            this.FillFromDataGridButton.Size = new System.Drawing.Size(107, 46);
            this.FillFromDataGridButton.TabIndex = 11;
            this.FillFromDataGridButton.Text = "FeedFromDataGrid";
            this.FillFromDataGridButton.UseVisualStyleBackColor = true;
            this.FillFromDataGridButton.Click += new System.EventHandler(this.FillFromDataGridButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 525);
            this.Controls.Add(this.FillFromDataGridButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FillFileButton);
            this.Controls.Add(this.FillRandom);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.InputDataGridView);
            this.Controls.Add(this.FillButton);
            this.Controls.Add(this.InputKeyBox);
            this.Controls.Add(this.InputValueBox);
            this.Controls.Add(this.AppendButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vlaue;
        private System.Windows.Forms.Button AppendButton;
        private System.Windows.Forms.TextBox InputValueBox;
        private System.Windows.Forms.TextBox InputKeyBox;
        private System.Windows.Forms.Button FillButton;
        private System.Windows.Forms.DataGridView InputDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button FillRandom;
        private System.Windows.Forms.Button FillFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FillFromDataGridButton;
    }
}

