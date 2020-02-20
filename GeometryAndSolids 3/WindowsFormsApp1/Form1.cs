using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Solids;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private bool renderFlag = true;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }

        public async void RenderSolids()
        {
            double alpha = 0;
            try
            {
                while (renderFlag)
                {
                    BasePlatonicSolid solid = null;

                    switch ((string)solidComboBox.SelectedItem)
                    {
                        case "Tetrahedron":
                            solid = new Tetrahedron(0, 0, 0, 100);
                            break;
                        case "Hexahedron":
                            solid = new Hexahedron(0, 0, 0, 100);
                            break;
                        case "Octahedron":
                            solid = new Octahedron(0, 0, 0, 100);
                            break;
                        case "Icosahedron":
                            solid = new Icosahedron(0, 0, 0, 100);
                            break;
                        case "Dodecahedron":
                            solid = new Dodecahedron(0, 0, 0, 100);
                            break;
                        default:
                            MessageBox.Show("something wrong");
                            return;
                    }
                    switch ((string)AxisRotationComboBox.SelectedItem)
                    {
                        case "OZ":
                            solid.RotateByZ(alpha);
                            break;
                        case "OY":
                            solid.RotateByY(alpha);
                            break;
                        case "OX":
                            solid.RotateByX(alpha);
                            break;
                        case "OXY":
                            solid.RotateByX(alpha);
                            solid.RotateByY(alpha);
                            break;
                        case "OZY":
                            solid.RotateByY(alpha);
                            solid.RotateByZ(alpha);
                            break;
                        case "OZX":
                            solid.RotateByX(alpha);
                            solid.RotateByZ(alpha);
                            break;
                        case "OXYZ":
                            solid.RotateByY(alpha);
                            solid.RotateByX(alpha);
                            solid.RotateByZ(alpha);
                            break;
                        case "Vectorized":
                            if(string.IsNullOrWhiteSpace(vectorXBox.Text) || string.IsNullOrWhiteSpace(vectorXBox.Text) || string.IsNullOrWhiteSpace(vectorXBox.Text))
                            {
                                MessageBox.Show("Vector is empty");
                                return;
                            }
                            solid.RotateByUnitVector(alpha, double.Parse(vectorXBox.Text), double.Parse(vectorYBox.Text), double.Parse(vectorZBox.Text));
                            break;
                        case "None":
                            break;
                        default:
                            MessageBox.Show("something wrong");
                            return;
                    }

                    if(!checkBox1.Checked)
                    {
                        solid.Scale(double.Parse(scaleBoxFx.Text), double.Parse(scaleBoxFy.Text), double.Parse(scaleBoxFz.Text));
                    }


                    solid.Shift(int.Parse(shiftXBox.Text), int.Parse(shiftYBox.Text), int.Parse(shiftZBox.Text));
                    graphics.Clear(pictureBox1.BackColor);
                    solid.DrawSolid(graphics, double.Parse(coeffBox.Text), double.Parse(angelBox.Text));
                    alpha += double.Parse(angularFrequencyBox.Text) / 10;
                    await Task.Delay(100);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("There were exception: " + e.Message);
            }
        }


        private void RenderButton_Click(object sender, EventArgs e)
        {
            renderFlag = true;
            RenderSolids();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            renderFlag = false;
            graphics.Clear(pictureBox1.BackColor);
        }

    }
}
