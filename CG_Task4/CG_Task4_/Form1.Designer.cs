namespace CG_Task4_
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
            this.FirstTable = new System.Windows.Forms.DataGridView();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.CanvasLabel = new System.Windows.Forms.Label();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.ReDrawButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.labelMouseY = new System.Windows.Forms.Label();
            this.labelMouseX = new System.Windows.Forms.Label();
            this.mousePosYLabel = new System.Windows.Forms.Label();
            this.mousePosXLabel = new System.Windows.Forms.Label();
            this.X1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FirstTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstTable
            // 
            this.FirstTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FirstTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X1,
            this.Y1,
            this.X2,
            this.Y2});
            this.FirstTable.Location = new System.Drawing.Point(548, 12);
            this.FirstTable.Name = "FirstTable";
            this.FirstTable.Size = new System.Drawing.Size(240, 426);
            this.FirstTable.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(13, 13);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(448, 425);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // CanvasLabel
            // 
            this.CanvasLabel.AutoSize = true;
            this.CanvasLabel.Location = new System.Drawing.Point(21, 22);
            this.CanvasLabel.Name = "CanvasLabel";
            this.CanvasLabel.Size = new System.Drawing.Size(43, 13);
            this.CanvasLabel.TabIndex = 2;
            this.CanvasLabel.Text = "Canvas";
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Location = new System.Drawing.Point(467, 12);
            this.DrawLineButton.Name = "DrawLineButton";
            this.DrawLineButton.Size = new System.Drawing.Size(75, 23);
            this.DrawLineButton.TabIndex = 3;
            this.DrawLineButton.Text = "Draw Line";
            this.DrawLineButton.UseVisualStyleBackColor = true;
            this.DrawLineButton.Click += new System.EventHandler(this.DrawLineButton_Click);
            // 
            // ReDrawButton
            // 
            this.ReDrawButton.Location = new System.Drawing.Point(467, 41);
            this.ReDrawButton.Name = "ReDrawButton";
            this.ReDrawButton.Size = new System.Drawing.Size(75, 23);
            this.ReDrawButton.TabIndex = 4;
            this.ReDrawButton.Text = "ReDraw";
            this.ReDrawButton.UseVisualStyleBackColor = true;
            this.ReDrawButton.Click += new System.EventHandler(this.ReDrawButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(467, 70);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // labelMouseY
            // 
            this.labelMouseY.AutoSize = true;
            this.labelMouseY.Location = new System.Drawing.Point(464, 214);
            this.labelMouseY.Name = "labelMouseY";
            this.labelMouseY.Size = new System.Drawing.Size(49, 13);
            this.labelMouseY.TabIndex = 6;
            this.labelMouseY.Text = "MouseY:";
            // 
            // labelMouseX
            // 
            this.labelMouseX.AutoSize = true;
            this.labelMouseX.Location = new System.Drawing.Point(464, 191);
            this.labelMouseX.Name = "labelMouseX";
            this.labelMouseX.Size = new System.Drawing.Size(49, 13);
            this.labelMouseX.TabIndex = 7;
            this.labelMouseX.Text = "MouseX:";
            // 
            // mousePosYLabel
            // 
            this.mousePosYLabel.AutoSize = true;
            this.mousePosYLabel.Location = new System.Drawing.Point(519, 214);
            this.mousePosYLabel.Name = "mousePosYLabel";
            this.mousePosYLabel.Size = new System.Drawing.Size(19, 13);
            this.mousePosYLabel.TabIndex = 8;
            this.mousePosYLabel.Text = "....";
            // 
            // mousePosXLabel
            // 
            this.mousePosXLabel.AutoSize = true;
            this.mousePosXLabel.Location = new System.Drawing.Point(519, 191);
            this.mousePosXLabel.Name = "mousePosXLabel";
            this.mousePosXLabel.Size = new System.Drawing.Size(19, 13);
            this.mousePosXLabel.TabIndex = 9;
            this.mousePosXLabel.Text = "....";
            // 
            // X1
            // 
            this.X1.HeaderText = "X1";
            this.X1.Name = "X1";
            this.X1.Width = 50;
            // 
            // Y1
            // 
            this.Y1.FillWeight = 50F;
            this.Y1.HeaderText = "Y1";
            this.Y1.Name = "Y1";
            this.Y1.Width = 50;
            // 
            // X2
            // 
            this.X2.HeaderText = "X2";
            this.X2.Name = "X2";
            this.X2.Width = 50;
            // 
            // Y2
            // 
            this.Y2.HeaderText = "Y2";
            this.Y2.Name = "Y2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mousePosXLabel);
            this.Controls.Add(this.mousePosYLabel);
            this.Controls.Add(this.labelMouseX);
            this.Controls.Add(this.labelMouseY);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ReDrawButton);
            this.Controls.Add(this.DrawLineButton);
            this.Controls.Add(this.CanvasLabel);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.FirstTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FirstTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView FirstTable;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label CanvasLabel;
        private System.Windows.Forms.Button DrawLineButton;
        private System.Windows.Forms.Button ReDrawButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label labelMouseY;
        private System.Windows.Forms.Label labelMouseX;
        private System.Windows.Forms.Label mousePosYLabel;
        private System.Windows.Forms.Label mousePosXLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn X1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y2;
    }
}

