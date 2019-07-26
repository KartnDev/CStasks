using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Task2._2
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttons = new System.Windows.Forms.Button[100];
            for(int i =0; i < 100; i++)
            {
                this.buttons[i] = new System.Windows.Forms.Button();
                
            }

            this.SuspendLayout();

            // 
            // button1
            // 

            textBox.Location = new System.Drawing.Point(410, 2);
            textBox.Size = new System.Drawing.Size(300, 200);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string textB = RandomString(new System.Random(i * 10 + j), 1, false);
                    this.buttons[i*10+j].Location = new System.Drawing.Point(40*i, 40*j);
                    this.buttons[i*10+j].Name = "button" + i;
                    this.buttons[i*10+j].Size = new System.Drawing.Size(30, 30);
                    this.buttons[i*10+j].TabIndex = 0;
                    this.buttons[i * 10 + j].Text = textB;
                    this.buttons[i*10+j].UseVisualStyleBackColor = true;
                    this.buttons[i * 10 + j].Click += new System.EventHandler((sender, e)=>{
                        this.textBox.Text += textB;
                        this.Update();
                    });
                }
            }
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            for (int i = 0; i < 100; i++)
            {
                this.Controls.Add(this.buttons[i]);
            }
            this.Controls.Add(this.textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button[] buttons;
        private System.Windows.Forms.TextBox textBox;
    }
}

