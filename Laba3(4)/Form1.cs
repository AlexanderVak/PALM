using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_4_
{
    public partial class Form1 : Form
    {
        Graphics gr, gr1;
        Bitmap myBtmp, myBtmp1;
        int x1, x2, y;
        float angle;
        Pen penForSpoke, penForWheel, penBlack; 
        public Form1()
        {
            InitializeComponent();
			pictureBox1.Controls.Add(pictureBox2);
			pictureBox2.Location = new Point(0, 0);
			pictureBox2.BackColor = Color.Transparent;


            penBlack = new Pen(Color.Black, 3);
        }
        void DrawFirstWheel(Graphics gr)
        {
            
            var rad = 25;
            // спиці
            penForSpoke = new Pen(Color.Black, 2);
            for (int i = 0; i < 360; i+=45)
            {
                gr.DrawLine(penForSpoke, 0, 0, rad, 0);
                gr.RotateTransform(45);
            }
            //шина

            penForWheel = new Pen(Color.DimGray, 8);
            gr.DrawEllipse(penForWheel, -rad + 5, -rad + 5, rad * 2 - 10, rad * 2 - 10);
            gr.DrawEllipse(penBlack, -rad, -rad, rad * 2, rad * 2);
            gr.DrawEllipse(penBlack, -rad + 10, -rad + 10, rad * 2 - 20, rad * 2 - 20);

            pictureBox1.Image = myBtmp;
        }



        void DrawSecondWheel(Graphics gr1)
        {

            var rad = 25;
            // спиці
            penForSpoke = new Pen(Color.Black, 2);
            for (int i = 0; i < 360; i += 45)
            {

                gr1.DrawLine(penForSpoke, -200, 0, -175, 0);

                gr1.TranslateTransform(-200, 0);
                gr1.RotateTransform(45);
                gr1.TranslateTransform(200, 0);
            }
            //шина

            
            //змінюємо х координату
            gr1.DrawEllipse(penForWheel, -rad + 5 - 200, -rad + 5, rad * 2 - 10, rad * 2 - 10);
            gr1.DrawEllipse(penBlack, -rad - 200, -rad, rad * 2, rad * 2);
            gr1.DrawEllipse(penBlack, -rad + 10 - 200, -rad + 10, rad * 2 - 20, rad * 2 - 20);

            pictureBox2.Image = myBtmp1;
        }

        private void DrawBody(Graphics gr)
        {
            SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
            SolidBrush windowBrush = new SolidBrush(Color.CornflowerBlue);
            SolidBrush greyBrush = new SolidBrush(Color.Gray);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

            Point point1 = new Point(-40, -20);
            Point point2 = new Point(40, -20);
            Point point3 = new Point(40, -50);
            Point point4 = new Point(15, -60);
            Point point5 = new Point(10, -90);
            Point point6 = new Point(-40, -90);
            Point[] pointsForBody = { point1, point2, point3, point4, point5, point6 };

            Rectangle headlight = new Rectangle(35, -47, 15, 15);
            gr.FillEllipse(yellowBrush, headlight);
            gr.DrawEllipse(penBlack, headlight);

            gr.FillPolygon(blueBrush, pointsForBody);
            gr.DrawPolygon(penBlack, pointsForBody);


            
            Rectangle window = new Rectangle(-32, -80, 30, 20);
            gr.FillRectangle(windowBrush, window);
            gr.DrawRectangle(penBlack, window);

            Rectangle handle = new Rectangle(-32, -50, 10, 5);
            gr.FillRectangle(greyBrush, handle);
            gr.DrawRectangle(penBlack, handle);

            Rectangle bumper = new Rectangle(30, -30, 20, 10);
            gr.FillRectangle(greyBrush, bumper);
            gr.DrawRectangle(penBlack, bumper);

            pictureBox1.Image = myBtmp;
        }

        private void DrawTrailer(Graphics gr)
        {
            SolidBrush brownBrush = new SolidBrush(Color.BurlyWood);
            SolidBrush orangeBrush = new SolidBrush(Color.Orange);

            Rectangle headlight = new Rectangle(-235, -35, 15, 15);
            gr.FillEllipse(orangeBrush, headlight);
            gr.DrawEllipse(penBlack, headlight);

            Rectangle trailerRect = new Rectangle(-225, -75, 185, 55);
            gr.FillRectangle(brownBrush, trailerRect);
            gr.DrawRectangle(penBlack, trailerRect);

            Point point1 = new Point(-225, -60);
            Point point2 = new Point(-40, -60);
            Point point3 = new Point(-225, -35);
            Point point4 = new Point(-40, -35);
            gr.DrawLine(penBlack, point1, point2);
            gr.DrawLine(penBlack, point3, point4);


            pictureBox1.Image = myBtmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //поворот спиць
            angle += 5f;
            // рух колеса

            x1 += 3;

            x2 += 3;
            Invalidate();

            myBtmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(myBtmp);

            // переносимо центр мас
            y = 300;
            gr.TranslateTransform(x1, y);
            DrawBody(gr);
            DrawTrailer(gr);
            gr.RotateTransform(angle);
            DrawFirstWheel(gr);
            myBtmp1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gr1 = Graphics.FromImage(myBtmp1);

            gr1.TranslateTransform(x2, y);

			DrawSecondWheel(gr1);








		}



        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }





    }
}
