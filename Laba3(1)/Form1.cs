using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int numOfSide = 5;
        int R = 60;
        Point Cntr;
        Point[] arrayOfPoints;

        private void BuildPentagon(double angle)
        {
            double phi = 0; int i = 0;
            while (i < numOfSide + 1)
            {
                arrayOfPoints[i].X = Cntr.X + (int)(Math.Round(Math.Cos(phi / 180 * Math.PI) * R));
                arrayOfPoints[i].Y = Cntr.Y - (int)(Math.Round(Math.Sin(phi / 180 * Math.PI) * R));
                phi += angle;
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cntr.X = 80;
            Cntr.Y = 95;

            arrayOfPoints = new Point[numOfSide + 1];
            BuildPentagon( (double)( 360.0 / (double)numOfSide));
            Graphics g = pictureBox1.CreateGraphics();
            while(numOfSide > 0)
            {
               g.DrawLine(new Pen(Color.Black, 2), arrayOfPoints[numOfSide], arrayOfPoints[numOfSide - 1]);
               numOfSide--;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
