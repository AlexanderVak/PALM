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
        int numOfSidePent = 5;
        Point Cntr;
        Point[] arrayOfPoints;
        Pen blackPen = new Pen(Color.Black, 2);

        private void BuildLineForPentagon(double angle, int numOfSide)
        {
            int R = 60;
            double phi = 0; int i = 0;
            while (i < numOfSide + 1)
            {
                arrayOfPoints[i].X = Cntr.X + (int)(Math.Round(Math.Cos(phi / 180 * Math.PI) * R));
                arrayOfPoints[i].Y = Cntr.Y - (int)(Math.Round(Math.Sin(phi / 180 * Math.PI) * R));
                phi += angle;
                i++;
            }
        }
        private void MyDrawPentagon(int numOfSide)
        {
            Cntr.X = 80;
            Cntr.Y = 95;
            arrayOfPoints = new Point[numOfSide + 1];
            BuildLineForPentagon( (double)( 360.0 / (double)numOfSide), numOfSidePent);
            Graphics g = pictureBox1.CreateGraphics();
            while (numOfSide > 0)
            {
               g.DrawLine(blackPen, arrayOfPoints[numOfSide], arrayOfPoints[numOfSide - 1]);
               numOfSide--;
            }
        }

        private void MyDrawPie()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rect = new Rectangle(45,3, 200, 100);
            float startAngle = 0.0F;
            float sweepAngle = 45.0F;
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
            g.FillPie(solidBrush, rect, startAngle, sweepAngle);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyDrawPentagon(numOfSidePent);
            MyDrawPie();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
