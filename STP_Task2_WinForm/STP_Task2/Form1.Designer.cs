namespace STP_Task2
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
            this.ArrayDataGrid = new System.Windows.Forms.DataGridView();
            this.Array = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CheckArrayButton = new System.Windows.Forms.Button();
            this.TaskText = new System.Windows.Forms.TextBox();
            this.TextLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ButtonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ArrayDataGrid
            // 
            this.ArrayDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ArrayDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArrayDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Array});
            this.ArrayDataGrid.Location = new System.Drawing.Point(12, 12);
            this.ArrayDataGrid.Name = "ArrayDataGrid";
            this.ArrayDataGrid.Size = new System.Drawing.Size(146, 426);
            this.ArrayDataGrid.TabIndex = 0;
            // 
            // Array
            // 
            this.Array.Frozen = true;
            this.Array.HeaderText = "ArrayValues:";
            this.Array.Name = "Array";
            // 
            // CheckArrayButton
            // 
            this.CheckArrayButton.Location = new System.Drawing.Point(164, 12);
            this.CheckArrayButton.Name = "CheckArrayButton";
            this.CheckArrayButton.Size = new System.Drawing.Size(75, 23);
            this.CheckArrayButton.TabIndex = 1;
            this.CheckArrayButton.Text = "CheckResult";
            this.CheckArrayButton.UseVisualStyleBackColor = true;
            this.CheckArrayButton.Click += new System.EventHandler(this.CheckArrayButton_Click);
            // 
            // TaskText
            // 
            this.TaskText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskText.Location = new System.Drawing.Point(426, 12);
            this.TaskText.Multiline = true;
            this.TaskText.Name = "TaskText";
            this.TaskText.ReadOnly = true;
            this.TaskText.Size = new System.Drawing.Size(362, 81);
            this.TaskText.TabIndex = 2;
            this.TaskText.Text = "1. Переменной t присвоить значение true, если в массиве нет нулевых элементов и п" +
    "ри этом положительные элементы чередуются с отрицательными и значение false в пр" +
    "отивном случае.";
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(245, 17);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(62, 13);
            this.TextLabel.TabIndex = 4;
            this.TextLabel.Text = "Result: T = ";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(302, 17);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(16, 13);
            this.ResultLabel.TabIndex = 5;
            this.ResultLabel.Text = "...";
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(164, 41);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 6;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.TaskText);
            this.Controls.Add(this.CheckArrayButton);
            this.Controls.Add(this.ArrayDataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ArrayDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ArrayDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Array;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button CheckArrayButton;
        private System.Windows.Forms.TextBox TaskText;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button ButtonClear;
    }
}

