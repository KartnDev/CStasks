using NumMethods1.InterpolationMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumMethods1
{
    public partial class Form1 : Form
    {
        Graphics _graphics;
        InterpolationGraphics interpolationGraphics;
        public Form1()
        {
            InitializeComponent();
            _graphics = canvasBox.CreateGraphics();
            interpolationGraphics = new InterpolationGraphics(_graphics, canvasBox.ClientRectangle);
        }
        private void RenderButtonOnClick(object sender, EventArgs e)
        {
            _graphics.Clear(this.BackColor);
            //TODO OR                                (x) => (float)(Math.Sin(x))
            interpolationGraphics.DrawInterpolation((x) => (float)(x > Math.PI ? Math.Sqrt(x) : Math.Sin(x +1)), (float)trackBar1.Value / 10);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _graphics.Clear(this.BackColor);
            RenderButtonOnClick(null, null);
        }
    }
}
