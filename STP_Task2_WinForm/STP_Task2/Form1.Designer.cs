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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Array = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CheckArrayButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GetArrayButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Array});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(146, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // Array
            // 
            this.Array.Frozen = true;
            this.Array.HeaderText = "ArrayValues:";
            this.Array.Name = "Array";
            // 
            // CheckArrayButton
            // 
            this.CheckArrayButton.Location = new System.Drawing.Point(164, 41);
            this.CheckArrayButton.Name = "CheckArrayButton";
            this.CheckArrayButton.Size = new System.Drawing.Size(75, 23);
            this.CheckArrayButton.TabIndex = 1;
            this.CheckArrayButton.Text = "CheckResult";
            this.CheckArrayButton.UseVisualStyleBackColor = true;
            this.CheckArrayButton.Click += new System.EventHandler(this.CheckArrayButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(426, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(362, 81);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1. Переменной t присвоить значение true, если в массиве нет нулевых элементов и п" +
    "ри этом положительные элементы чередуются с отрицательными и значение false в пр" +
    "отивном случае.";
            // 
            // GetArrayButton
            // 
            this.GetArrayButton.Location = new System.Drawing.Point(164, 12);
            this.GetArrayButton.Name = "GetArrayButton";
            this.GetArrayButton.Size = new System.Drawing.Size(75, 23);
            this.GetArrayButton.TabIndex = 3;
            this.GetArrayButton.Text = "Get Array ";
            this.GetArrayButton.UseVisualStyleBackColor = true;
            this.GetArrayButton.Click += new System.EventHandler(this.GetArrayButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Result: T = ";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(313, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetArrayButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CheckArrayButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Array;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button CheckArrayButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GetArrayButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

