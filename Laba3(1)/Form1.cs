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
        private void DrawPentagon(int numOfSide, Graphics g)
        {
            Cntr.X = 80;
            Cntr.Y = 95;
            arrayOfPoints = new Point[numOfSide + 1];
            BuildLineForPentagon( (double)( 360.0 / (double)numOfSide), numOfSidePent);
            while (numOfSide > 0)
            {
               g.DrawLine(blackPen, arrayOfPoints[numOfSide], arrayOfPoints[numOfSide - 1]);
               numOfSide--;
            }
        }

        private void MyDrawPie(Graphics g)
        {
            Rectangle rect = new Rectangle(45,3, 200, 100);
            float startAngle = 0.0F;
            float sweepAngle = 45.0F;
            SolidBrush solidBrush = new SolidBrush(Color.Green);
            g.DrawPie(blackPen, rect, startAngle, sweepAngle);
            g.FillPie(solidBrush, rect, startAngle, sweepAngle);
            
        }

        private void DrawRhombus (Pen blackPen, Graphics g)
        {
            int X = 400;
            int Y = 400;
            Point point1 = new Point(X, Y );
            Point point2 = new Point(X - 50, Y - 100);
            Point point3 = new Point(X + 50, Y - 100 );
            Point point4 = new Point(X, Y - 200);
            Point[] pointsArrayOfRhombus = { point1, point2, point4, point3};
            g.DrawPolygon(blackPen, pointsArrayOfRhombus);
        }

        private void DrawCube(Pen blackPen, Graphics g)
        {
            int X1 = 600;
            int Y1 = 100;
            int X2 = 650;
            int Y2 = 65;
            g.DrawRectangle(blackPen, 600, 100, 200, 200);
            g.DrawRectangle(blackPen, 650, 65, 200, 200);
            g.DrawLine(blackPen, X1, Y1, X2, Y2);
            g.DrawLine(blackPen, X1 + 200, Y1, X2 + 200, Y2);
            g.DrawLine(blackPen, X1, Y1 + 200, X2, Y2 + 200);
            g.DrawLine(blackPen, X1 + 200, Y1 + 200, X2 + 200, Y2 + 200);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(myBitmap);
            DrawPentagon(numOfSidePent, g);
            MyDrawPie(g);
            DrawRhombus(blackPen, g);
            DrawCube(blackPen, g);
            pictureBox1.Image = myBitmap;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
