using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Task2._2
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;
 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttons = new System.Windows.Forms.Button[50];
            for(int i =0; i < 50; i++)
            {
                this.buttons[i] = new System.Windows.Forms.Button();
                
            }

            this.SuspendLayout();

            textBox.Location = new System.Drawing.Point(210, 2);
            textBox.Size = new System.Drawing.Size(300, 200);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string textB = RandomCharAsString(new System.Random(i * 10 + j), ref this.CorrentSymbols);
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
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 410);
            for (int i = 0; i < 50; i++)
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

