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
        Graphics gr;
        Bitmap myBtmp;
        int x, y;
        float angle;
        Pen penForSpoke, penForWheel1, penForWheel2; 
        public Form1()
        {
            InitializeComponent();
           
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
            penForWheel1 = new Pen(Color.Black, 3);
            penForWheel2 = new Pen(Color.DimGray, 8);
            gr.DrawEllipse(penForWheel2, -rad + 5, -rad + 5, rad * 2 - 10, rad * 2 - 10);
            gr.DrawEllipse(penForWheel1, -rad, -rad, rad * 2, rad * 2);
            gr.DrawEllipse(penForWheel1, -rad + 10, -rad + 10, rad * 2 - 20, rad * 2 - 20);

            pictureBox1.Image = myBtmp;
        }
        void DrawSecondWheel(Graphics gr)
        {

            var rad = 25;
            // спиці
            penForSpoke = new Pen(Color.Black, 2);
            for (int i = 0; i < 360; i += 45)
            {
                gr.DrawLine(penForSpoke, 0, 0, rad, 0);
                gr.RotateTransform(45);
            }
            //шина
            penForWheel1 = new Pen(Color.Black, 3);
            penForWheel2 = new Pen(Color.DimGray, 8);
            //змінюємо х координату
            gr.DrawEllipse(penForWheel2, -rad + 5 - 150, -rad + 5, rad * 2 - 10, rad * 2 - 10);
            gr.DrawEllipse(penForWheel1, -rad - 150, -rad, rad * 2, rad * 2);
            gr.DrawEllipse(penForWheel1, -rad + 10 - 150, -rad + 10, rad * 2 - 20, rad * 2 - 20);

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
            x += 3;
            Invalidate();
            myBtmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(myBtmp);
            // переносимо центр мас
            y = 200;
            gr.TranslateTransform(x, y);
            gr.RotateTransform(angle);
            DrawFirstWheel(gr);
            y = 200;
            gr.TranslateTransform(x, y);

            DrawSecondWheel(gr);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }





    }
}
