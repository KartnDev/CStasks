namespace STP_Task3_WinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CenterX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computeButton = new System.Windows.Forms.Button();
            this.PosXTextBox = new System.Windows.Forms.TextBox();
            this.posYTextBox = new System.Windows.Forms.TextBox();
            this.taskText = new System.Windows.Forms.Label();
            this.pointYLable = new System.Windows.Forms.Label();
            this.pointXlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CenterX,
            this.CenterY,
            this.Radius});
            this.dataGridView1.Location = new System.Drawing.Point(594, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(194, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // CenterX
            // 
            this.CenterX.HeaderText = "CenterX";
            this.CenterX.Name = "CenterX";
            this.CenterX.Width = 50;
            // 
            // CenterY
            // 
            this.CenterY.HeaderText = "CenterY";
            this.CenterY.Name = "CenterY";
            this.CenterY.Width = 50;
            // 
            // Radius
            // 
            this.Radius.HeaderText = "Radius";
            this.Radius.Name = "Radius";
            this.Radius.Width = 50;
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(450, 11);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(138, 44);
            this.computeButton.TabIndex = 1;
            this.computeButton.Text = "Compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // PosXTextBox
            // 
            this.PosXTextBox.Location = new System.Drawing.Point(488, 61);
            this.PosXTextBox.Name = "PosXTextBox";
            this.PosXTextBox.Size = new System.Drawing.Size(100, 20);
            this.PosXTextBox.TabIndex = 2;
            // 
            // posYTextBox
            // 
            this.posYTextBox.Location = new System.Drawing.Point(488, 87);
            this.posYTextBox.Name = "posYTextBox";
            this.posYTextBox.Size = new System.Drawing.Size(100, 20);
            this.posYTextBox.TabIndex = 3;
            // 
            // taskText
            // 
            this.taskText.AutoSize = true;
            this.taskText.Location = new System.Drawing.Point(12, 11);
            this.taskText.Name = "taskText";
            this.taskText.Size = new System.Drawing.Size(419, 65);
            this.taskText.TabIndex = 4;
            this.taskText.Text = resources.GetString("taskText.Text");
            // 
            // pointYLable
            // 
            this.pointYLable.AutoSize = true;
            this.pointYLable.Location = new System.Drawing.Point(447, 94);
            this.pointYLable.Name = "pointYLable";
            this.pointYLable.Size = new System.Drawing.Size(38, 13);
            this.pointYLable.TabIndex = 5;
            this.pointYLable.Text = "PointY";
            // 
            // pointXlabel
            // 
            this.pointXlabel.AutoSize = true;
            this.pointXlabel.Location = new System.Drawing.Point(447, 68);
            this.pointXlabel.Name = "pointXlabel";
            this.pointXlabel.Size = new System.Drawing.Size(38, 13);
            this.pointXlabel.TabIndex = 6;
            this.pointXlabel.Text = "PointX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pointXlabel);
            this.Controls.Add(this.pointYLable);
            this.Controls.Add(this.taskText);
            this.Controls.Add(this.posYTextBox);
            this.Controls.Add(this.PosXTextBox);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radius;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.TextBox PosXTextBox;
        private System.Windows.Forms.TextBox posYTextBox;
        private System.Windows.Forms.Label taskText;
        private System.Windows.Forms.Label pointYLable;
        private System.Windows.Forms.Label pointXlabel;
    }
}

